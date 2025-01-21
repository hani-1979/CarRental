using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Repositories;
using CarRentalApp.Services;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IRepository<Branch>), typeof(BranchRepository<Branch>));

builder.Services.AddScoped(typeof(IRepository<Colour>), typeof(ColorRepository<Colour>));
builder.Services.AddScoped(typeof(IRepository<Manufactorer>), typeof(ManufactorerRepository<Manufactorer>));
builder.Services.AddScoped(typeof(IRepository<Modeel>), typeof(ModeelRepository<Modeel>));
builder.Services.AddScoped(typeof(IRepository<Classification>), typeof(ClassificationRepository<Classification>));
builder.Services.AddScoped(typeof(IRepository<Company>), typeof(CompanyRepository<Company>));
builder.Services.AddScoped(typeof(IRepository<Car>), typeof(CarRepository<Car>));
builder.Services.AddScoped(typeof(IRepository<Insurance>), typeof(InsuranceRepository<Insurance>));
builder.Services.AddScoped(typeof(IRepository<Accident>), typeof(AccidentRepository<Accident>));
builder.Services.AddScoped(typeof(IRepository<carClaim>),typeof(carClaimRepository<carClaim>));
builder.Services.AddScoped(typeof(IRepository<Estimation>), typeof(EstimationRepsitory<Estimation>));



builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IManufactorerservice, ManufactorerService>();
builder.Services.AddScoped<IModeelService, ModeelService>();
builder.Services.AddScoped<IClassificationService, ClassificationService>();
builder.Services.AddScoped<IColourService, ColourService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IInsuranceService, InsuranceService>();
builder.Services.AddScoped<IAccidentService, AccidentService>();
builder.Services.AddScoped<ICarClaimService, CarClaimService>();
builder.Services.AddScoped<IUpdateStatusService, UpdateStatusService>();
builder.Services.AddScoped<IEstimationService ,EstimationService>();
builder.Services.AddSingleton<PdfService>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("DBCS")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

//app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=account}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
