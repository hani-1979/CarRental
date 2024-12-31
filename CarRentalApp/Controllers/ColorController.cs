using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers
{
    public class ColorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IColourService _colourService;

        public ColorController(AppDbContext context,IColourService colourService)
        {
            _context = context;
            _colourService = colourService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var colors = await _colourService.GetAllColourAsync();
            return View(colors); // Passes the list of branches to the view

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(); // Passes the list of branches to the view

        }
        [HttpPost]
        public async Task<IActionResult> Create(Colour model)
        {
            if (ModelState.IsValid)
            {
                await _colourService.AddColourAsync(model);
                return RedirectToAction(nameof(Index)); // Redirect to the index page after successful creation
            }
            return View(model); // Return the form with validation errors if any

        }
    }
}
