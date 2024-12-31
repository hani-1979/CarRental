using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers
{
    public class InsuranceCompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
