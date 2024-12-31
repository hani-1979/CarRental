using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers
{
    public class ClassificationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IClassificationService _classificationService;

        public ClassificationController(AppDbContext context,IClassificationService classificationService)
        {
            _context = context;
            _classificationService = classificationService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var colors = await _classificationService.GetAllClassificationAsync();
            return View(colors); // Passes the list of branches to the view

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(); // Passes the list of branches to the view

        }
        [HttpPost]
        public async Task<IActionResult> Create(Classification model)
        {
            if (ModelState.IsValid)
            {
                await _classificationService.AddClassificationAsync(model);
                return RedirectToAction(nameof(Index)); // Redirect to the index page after successful creation
            }
            return View(model); // Return the form with validation errors if any

        }
    }
}
