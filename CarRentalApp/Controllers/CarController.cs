﻿using CarRentalApp.Models;
using CarRentalApp.Services;
using CarRentalApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Net.Mail;

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

        public CarController(ICarService carService,IBranchService branchService,IColourService colourService,
            IManufactorerservice manufactorerservice,
            IModeelService modeelService, IClassificationService classificationService)
        {
            _carService = carService;
            _branchService = branchService;
            _modeelService = modeelService;
            _manufactorerservice = manufactorerservice;
            _classificationService = classificationService;
            _colourService = colourService;
        }
      
        public async Task<IActionResult> Index()
        {
            var model = await _carService.GetAllCarsAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CarCreateViewModel
            {
                branches = (List<Branch>) await _branchService.GetAllBranchesAsync(),
                manufactorers=(List<Manufactorer>) await _manufactorerservice.GetAllManufactorerAsync(),
                modeels = (List<Modeel>)await _modeelService.GetAllModeelsAsync(),
                classifications=(List<Classification>) await _classificationService.GetAllClassificationAsync(),
                colours = (List<Colour>) await _colourService.GetAllColourAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateViewModel model)
        {
            try
            {

                if (ModelState.IsValid)

                {
                    
                    Car car = new Car()
                    {
                        Yearfmanufacture = model.Yearfmanufacture,
                        Branch = await _branchService.GetBranchByIdAsync(model.BranchId),
                        Colours = await _colourService.GetColourByIdAsync(model.ColourId),
                        Manufactorer = await _manufactorerservice.GetManufactorerByIdAsync(model.ManufactorerId),
                        Modeel = await _modeelService.GetModeelByIdAsync(model.ModeelId),
                        Classification = await _classificationService.GetClassificationByIdAsync(model.classificationId),
                        ChassisNumber = model.ChassisNumber,
                        PlateNumber= model.PlateNumber,
                        FormNumber= model.FormNumber,
                        BDFormNumber= model.BDFormNumber,
                        EDFormNumber = model.EDFormNumber,
                        CheckNumber = model.CheckNumber,
                        BDCheckNumber = model.BDCheckNumber,
                        EDCheckNumber = model.EDCheckNumber,
                        CartNumber = model.CartNumber
                    };

                    await _carService.AddCarAsync(car);
                   
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}
