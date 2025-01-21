using CarRentalApp.Models;
using CarRentalApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            var company = await _companyService.GetAllCompany();
            return View(company); // Passes the list of branches to the view
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(); // Passes the list of branches to the view

        }
        [HttpPost]
        public async Task<IActionResult> Create(Company model)
        {
            if (ModelState.IsValid)
            {
                await _companyService.addCompany(model);
                return RedirectToAction(nameof(Index)); // Redirect to the index page after successful creation
            }
            return View(model); // Return the form with validation errors if any

        }
    }
}
