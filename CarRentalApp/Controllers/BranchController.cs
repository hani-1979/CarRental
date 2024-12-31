using CarRentalApp.Models;
using CarRentalApp.Repositories;
using CarRentalApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;


        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
            
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var branches = await _branchService.GetAllBranchesAsync();
            return View(branches); // Passes the list of branches to the view

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
           
          return View(); // Passes the list of branches to the view

        }
        [HttpPost]
        public async Task<IActionResult> Create(Branch model)
        {
            if (ModelState.IsValid)
            {
                await _branchService.AddBranchAsync(model);
                return RedirectToAction(nameof(Index)); // Redirect to the index page after successful creation
            }
            return View(model); // Return the form with validation errors if any

        }
    }
}
