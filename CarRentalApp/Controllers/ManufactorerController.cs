using CarRentalApp.Models;
using CarRentalApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers
{
    public class ManufactorerController : Controller
    {
        private readonly IManufactorerservice _manufactorerservice;

        public ManufactorerController(IManufactorerservice manufactorerservice)
        {
            _manufactorerservice = manufactorerservice;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Manufactorer = await _manufactorerservice.GetAllManufactorerAsync();
            return View(Manufactorer); // Passes the list of branches to the view

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(); // Passes the list of branches to the view

        }
        [HttpPost]
        public async Task<IActionResult> Create(Manufactorer model)
        {
            if (ModelState.IsValid)
            {
                await _manufactorerservice.AddManufactorerAsync(model);
                return RedirectToAction(nameof(Index)); // Redirect to the index page after successful creation
            }
            return View(model); // Return the form with validation errors if any

        }
    }
}
