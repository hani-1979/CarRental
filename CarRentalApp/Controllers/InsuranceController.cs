using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Services;
using CarRentalApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;

namespace CarRentalApp.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly IInsuranceService _insuranceService;
        private readonly ICompanyService _companyService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly AppDbContext _context;
        private readonly ICarService _carService;
        private readonly string _uploadFolderPath;

        public InsuranceController(IInsuranceService insuranceService, ICompanyService companyService, IWebHostEnvironment hostEnvironment, AppDbContext context, IHostEnvironment environment, ICarService carService)
        {
            _insuranceService = insuranceService;
            _companyService = companyService;
            _hostEnvironment = hostEnvironment;
            _context = context;
            _carService = carService;
            _uploadFolderPath = Path.Combine(environment.ContentRootPath, "wwwroot", "images");
            if (!Directory.Exists(_uploadFolderPath))
            {
                Directory.CreateDirectory(_uploadFolderPath);
            }
        }
        public async Task<IActionResult> Index()
        {
            var ins = from Insurance in _context.Insurances
                      join car in _context.Cars on Insurance.CarId equals car.CarId
                      join company in _context.Companys on Insurance.CompanyId equals company.CompanyId
                      select new InsuranceViewModel
                      {

                          InsuranceId = Insurance.InsuranceId,
                          CompanyNameAr = company.CompanyNameAr,
                          PlateNumber = car.PlateNumber,
                          PolicyNumber = Insurance.PolicyNumber,
                          BDPolicyNumber = Insurance.BDPolicyNumber,
                          EDPolicyNumber = Insurance.EDPolicyNumber // Assuming the Manufacturer model has a 'Name' property
                      };

            // Execute the query and get the results
            var resultList = ins.ToList();
            return View(ins);

        }
        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var model = new InsuranceViewModel
            {
                CarId = Id,
                companies = (List<Company>)await _companyService.GetAllCompany()


            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(InsuranceViewModel model, List<IFormFile> files)
        {
            try
            {

                if (ModelState.IsValid)

                {
                    string uniqueFileName = ProcessUplodedFile(model);
                    Insurance insurance = new Insurance()
                    {

                        Company = await _companyService.GetCompanyById(model.CompanyId),
                        CarId = model.CarId,
                        PolicyNumber = model.PolicyNumber,
                        BDPolicyNumber = model.BDPolicyNumber,
                        EDPolicyNumber = model.EDPolicyNumber,
                        PhothPath = uniqueFileName
                    };
                    await _insuranceService.AddInsurace(insurance);
                    await _insuranceService.UpdateInsuranceStatus(insurance.CarId);

                    if (files != null)
                    {
                        foreach (var file in files)
                        {
                            // Validate file type and size
                            if (file.Length > 0 && file.Length <= 1048576) // 1 MB limit
                            {
                                var filePath = Path.Combine(_uploadFolderPath, file.FileName);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }

                                var attachment = new Attachment
                                {
                                    FileName = file.FileName,
                                    FilePath = $"/images/{file.FileName}", // Store the relative path
                                    ContentType = file.ContentType,
                                    InsuranceId = insurance.InsuranceId
                                };
                                _context.Attachments.Add(attachment);
                            }
                        }

                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<IActionResult> DownloadAttachments(int Id)
        {

            var insurance = await _context.Insurances
                .Include(w => w.Attachments)
                .FirstOrDefaultAsync(w => w.InsuranceId == Id);

            if (insurance == null || !insurance.Attachments.Any())
            {
                return NotFound("No attachments found for this employee.");
            }

            var zipFileName = $"{insurance.PolicyNumber}_Attachments.zip";
            var zipFilePath = Path.Combine(Path.GetTempPath(), zipFileName);

            using (var zipArchive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                foreach (var attachment in insurance.Attachments)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", attachment.FilePath.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        zipArchive.CreateEntryFromFile(filePath, attachment.FileName);
                    }
                }
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(zipFilePath);
            System.IO.File.Delete(zipFilePath); // Delete the zip file after downloading

            return File(fileBytes, "application/zip", zipFileName);

        }

        private string ProcessUplodedFile(InsuranceViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return uniqueFileName;
        }
        
    }
}
    

