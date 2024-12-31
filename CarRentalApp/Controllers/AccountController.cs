using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Services;
using CarRentalApp.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        [HttpGet]
        public IActionResult Login()
        { return View(); }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.userAccounts.Where(x => (x.userId == model.userI || x.UserName == model.UserNameOrEmail || x.Email == model.UserNameOrEmail) && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    var claims = new List<Claim>
                    {

                        //new Claim(ClaimTypes.Name , user.Id),
                        new Claim(ClaimTypes.Name,user.Email),
                        new Claim("FirstName", user.UserName),
                        new Claim(ClaimTypes.Role,"User")
                    };
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
                    return RedirectToAction("Index", "Home");
                    //  return RedirectToAction("SecurePage");
                }
                else
                {

                    ModelState.AddModelError("", "UserName/Emai Or password Is Not Correct");
                }
            }
            return View();
        }
    }
}
