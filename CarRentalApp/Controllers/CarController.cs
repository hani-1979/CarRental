using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Services;
using CarRentalApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalApp.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBranchService _branchService;
        private readonly IColourService _colourService;
        private readonly IManufactorerservice _manufactorerservice;
        private readonly IModeelService _modeelService;
        private readonly IClassificationService _classificationService;
        private readonly AppDbContext _context;
        private readonly ILogger<CarController> _logger;

        public CarController(
            ICarService carService,
            IBranchService branchService,
            IColourService colourService,
            IManufactorerservice manufactorerservice,
            IModeelService modeelService,
            IClassificationService classificationService,
            AppDbContext context,
            ILogger<CarController> logger)
        {
            _carService = carService;
            _branchService = branchService;
            _modeelService = modeelService;
            _manufactorerservice = manufactorerservice;
            _classificationService = classificationService;
            _context = context;
            _colourService = colourService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var cars = await _context.Cars
                    .Include(c => c.Modeel)
                    .Select(c => new CarCreateViewModel
                    {
                        CarId = c.CarId,
                        PlateNumber = c.PlateNumber,
                        ChassisNumber = c.ChassisNumber,
                        ModeelNameAr = c.Modeel.ModeelNameAr,
                    })
                    .ToListAsync();

                return View(cars);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving car list");
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var model = new CarCreateViewModel
                {
                    branches = (List<Branch>)await _branchService.GetAllBranchesAsync(),
                    manufactorers = await _context.Manufactorers.ToListAsync(),
                    modeels = new List<Modeel>(),
                    classifications = (List<Classification>)await _classificationService.GetAllClassificationAsync(),
                    colours = (List<Colour>)await _colourService.GetAllColourAsync()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading create car form");
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var car = new Car()
                    {
                        Yearfmanufacture = model.Yearfmanufacture,
                        BranchId = model.BranchId,
                        ColourId = model.ColourId,
                        ManufactorerId = model.ManufactorerId,
                        ModeelId = model.ModeelId,
                        classificationId = model.classificationId,
                        ChassisNumber = model.ChassisNumber,
                        PlateNumber = model.PlateNumber,
                        FormNumber = model.FormNumber,
                        BDFormNumber = model.BDFormNumber,
                        EDFormNumber = model.EDFormNumber,
                        CheckNumber = model.CheckNumber,
                        BDCheckNumber = model.BDCheckNumber,
                        EDCheckNumber = model.EDCheckNumber,
                        CartNumber = model.CartNumber,
                        InsuraceStatus = 0,
                        AccidenStatus = 0,
                        ClaimStatus = 0,
                    };

                    await _carService.AddCarAsync(car);
                    return RedirectToAction(nameof(Index));
                }

                await ReloadModelData(model);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new car");
                ModelState.AddModelError("", "حدث خطأ أثناء حفظ البيانات");
                await ReloadModelData(model);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetModelsByManufacturer(int manufactorerId)
        {
            try
            {
                var models = await _context.Modeels
                    .Where(m => m.ManufactorerId == manufactorerId)
                    .Select(m => new {
                        modeelId = m.ModeelId,
                        modeelNameAr = m.ModeelNameAr
                    })
                    .ToListAsync();

                return Json(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting models for manufacturer {manufactorerId}");
                return StatusCode(500, "Internal server error");
            }
        }

        private async Task ReloadModelData(CarCreateViewModel model)
        {
            model.branches = (List<Branch>)await _branchService.GetAllBranchesAsync();
            model.manufactorers = await _context.Manufactorers.ToListAsync();
            model.classifications = (List<Classification>)await _classificationService.GetAllClassificationAsync();
            model.colours = (List<Colour>)await _colourService.GetAllColourAsync();
            model.modeels = new List<Modeel>();
        }
    }
}