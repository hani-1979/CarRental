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

        public ModeelController(AppDbContext context,IManufactorerservice manufactorerservice)
        {
            _context = context;
            _manufactorerservice = manufactorerservice;
        }
        public IActionResult Index()
        {
            return View();
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
