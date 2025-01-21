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
        public async Task<IActionResult> Index()
        {
            var user = _context.userAccounts
              .Join(_context.Branches, // Assuming there's a Manufacturers table in your database
                    user => user.BranchId, // Foreign key on Modeel (Car) to Manufacturer
                    Branch => Branch.BranchId, // Primary key of Manufacturer
                    (user, Branch) => new RegistrationViewModel
                    {
                        BranchNameAr = Branch.BranchNameAr,
                        UserName = user.UserName,
                        Email = user.Email // Assuming the Manufacturer model has a 'Name' property
                        
                    })
              .ToList();
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            var model = new RegistrationViewModel
            {
                branches = (List<Branch>) await _branchService.GetAllBranchesAsync(),
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
                        Email=model.Email,
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

                    ModelState.AddModelError("", "إسم المستخدم أو كلمة المرور غير صحيحة");
                }
            }
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
