using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Services;
using CarRentalApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Controllers
{
    public class ModeelController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IManufactorerservice _manufactorerservice;
        private readonly IModeelService _modeelService;

        public ModeelController(AppDbContext context,IManufactorerservice manufactorerservice,IModeelService modeelService)
        {
            _context = context;
            _manufactorerservice = manufactorerservice;
            _modeelService = modeelService;
        }
        public async Task<IActionResult> Index()
        {
            var cars = _context.Modeels
             .Join(_context.Manufactorers, // Assuming there's a Manufacturers table in your database
                   car => car.ManufactorerId, // Foreign key on Modeel (Car) to Manufacturer
                   manufacturer => manufacturer.ManufactorerId, // Primary key of Manufacturer
                   (car, manufacturer) => new ManufaCarViewModel
                   {
                       ManufactorNameAr = manufacturer.ManufactorNameAr,
                       ModeelNameAr = car.ModeelNameAr,
                       ModeelNameEn = car.ModeelNameEn // Assuming the Manufacturer model has a 'Name' property
                   })
             .ToList();
            return View(cars);
        }
        public async Task<IActionResult> Create()
        {
            var model = new ManufaCarViewModel
            {
                Manufactorers = (List<Manufactorer>)await _manufactorerservice.GetAllManufactorerAsync(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ManufaCarViewModel model)
        {
            try
            {
                if (ModelState.IsValid)

                {

                    Modeel modeel = new  Modeel()
                    {

                        Manufactorer = await _manufactorerservice.GetManufactorerByIdAsync(model.ManufactorerId),
                        ModeelNameAr = model.ModeelNameAr,
                        ModeelNameEn = model.ModeelNameEn,
                      
                    };

                    await _context.AddAsync(modeel);
                    _context.SaveChanges();
                    ModelState.Clear();
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
