using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Services;
using CarRentalApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBranchService _branchService;

        public AccountController(AppDbContext context, IBranchService branchService)
        {
            _context = context;
            _branchService = branchService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            var model = new RegistrationViewModel
            {
                branches = (List<Branch>)await _branchService.GetAllBranchesAsync(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)

                {

                    UserAccount userAccount = new UserAccount()
                    {

                        Branch = await _branchService.GetBranchByIdAsync((int)model.BranchId),
                        UserName = model.UserName,
                        Password = model.Password,
                        IsAdmin = model.IsAdmin,

                    };

                    await _context.AddAsync(userAccount);

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
