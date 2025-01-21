using CarRentalApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Controllers
{
    public class dashboardController : Controller
    {
        private readonly AppDbContext _context;

        public dashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var carCount = _context.Cars.Count();
            return View(carCount);
        }

        // Action to handle the button click and increment the car count
        [HttpPost]
        public IActionResult CountCar()
        {
            // Incrementing the car count directly from the database isn't typical; 
            // this would instead trigger some operation, but let's show how to count again
            var carCount = _context.Cars.Count();
            return Json(new { count = carCount });
        }
        public IActionResult CountAccident()
        {
            // Incrementing the car count directly from the database isn't typical; 
            // this would instead trigger some operation, but let's show how to count again

            var CountAccident = _context.Cars.Where(c => c.AccidenStatus == 1).ToList();
           
            return Json(new { count = CountAccident });
        }
    }
}
