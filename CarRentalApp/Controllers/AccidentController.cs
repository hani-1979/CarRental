using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Repositories;
using CarRentalApp.Services;
using CarRentalApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Composition;
using System.IO.Compression;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace CarRentalApp.Controllers
{
    public class AccidentController : Controller
    {
        private readonly IAccidentService _accidentService;
        private readonly IBranchService _branchService;
        private readonly IModeelService _modeelService;
        private readonly  AppDbContext _context;
        private readonly ICarService _carService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ICompanyService _companyService;
        private readonly string _uploadFolderPath;
        private readonly string _uploadFolderPath1;

        public AccidentController(IAccidentService  accidentService,IBranchService branchService, IModeelService modeelService,AppDbContext context,ICarService carService, IWebHostEnvironment hostEnvironment, IHostEnvironment environment,ICompanyService companyService)
        {
            _accidentService = accidentService;
            _branchService = branchService;
            _modeelService = modeelService;
            _context = context;
            _carService = carService;
            _hostEnvironment = hostEnvironment;
             _companyService = companyService;
            _uploadFolderPath = Path.Combine(environment.ContentRootPath, "wwwroot", "Accident");
            if (!Directory.Exists(_uploadFolderPath))
            {
                Directory.CreateDirectory(_uploadFolderPath);
            }
            _uploadFolderPath1 = Path.Combine(environment.ContentRootPath, "wwwroot", "AccidentPic");
            if (!Directory.Exists(_uploadFolderPath1))
            {
                Directory.CreateDirectory(_uploadFolderPath1);
            }
        }
        public async Task<IActionResult> Index()
        {
            var accidentData = from accident in _context.Accidents
                               join car in _context.Cars on accident.CarId equals car.CarId
                               join company in _context.Companys on accident.CompanyId equals company.CompanyId
                               join Trafficreport in _context.Trafficreports on accident.TrafficreportId equals Trafficreport.TrafficreportId
                              // join AccidentAttachment in _context.accidentAttachments on accident.AccidentId equals AccidentAttachment.AccidentId

                               select new AccidentCarViewModel
                               {
                                   //FileName=AccidentAttachment.FileName,
                                   //FilePath=AccidentAttachment.FilePath,
                                   AccidentId = accident.AccidentId,
                                   TrafficreportId = Trafficreport.TrafficreportId,
                                   TrafficreportName=Trafficreport.TrafficreportName,
                                   CarId = accident.CarId,
                                   ChassisNumber = car.ChassisNumber,
                                   PlateNumber = car.PlateNumber,
                                   CompanyNameAr = company.CompanyNameAr,
                                   AccidentDate = accident.AccidentDate,
                                   AccidentStatus = accident.AccidentStatus,
                                   DriverName=accident.DriverName,
                                   DriverIdentity = accident.DriverIdentity,
                                   DriveLicence=accident.DriveLicence,
                                   AccidentNumber = accident.AccidentNumber,

                               };

            // Execute the query and get the results
            var resultList = accidentData.ToList();
            return View(accidentData);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var model = new AccidentCarViewModel
            {
                CarId = Id,
                CompanyId = (int)await _companyService.GetCompanyByCarIdAsync(Id),

                trafficreports = await _context.Trafficreports.ToListAsync(),
                BranchId = (int)await _branchService.GetBranchByCarIdAsync(Id),


            };
            return View(model);
        }
            [HttpPost]
        public async Task<IActionResult> Create(AccidentCarViewModel model, List<IFormFile> files, List<IFormFile> filess)
        {
            try
            {
                if (ModelState.IsValid)

                {
                   // string uniqueFileName = ProcessUplodedFile(model);
                    Accident accident = new Accident()
                    {

                        AccidentId=model.AccidentId,
                        CarId = model.CarId,
                        CompanyId = model.CompanyId,
                        TrafficreportId = model.TrafficreportId,
                        BranchId = model.BranchId,
                        AccidentNumber=model.AccidentNumber,
                        Percentage=model.Percentage,
                        AccidentDate = model.AccidentDate,
                        Description = model.Description,
                        DriverName = model.DriverName,
                        DriveLicence = model.DriveLicence,
                        DriverIdentity = model.DriverIdentity,
                        DriverNameOther = model.DriverNameOther,
                        DriverIdentityOther = model.DriverIdentityOther,  
                        DriveLicenceOther = model.DriveLicenceOther,
                        DriverCompanyOther = model.DriverCompanyOther,
                        AccidentStatus = 2,
                        
                       // PhothPath = uniqueFileName
                    };

                    await _accidentService.AddAccident(accident);

                    await _carService.UpdateCarAccidentStatusAsync(accident.CarId);
                   // await _carService.UpdateCarAsync(car)
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

                                var accidentAttachment = new AccidentAttachment
                                {
                                    FileName = file.FileName,
                                    FilePath = $"/Accident/{file.FileName}", // Store the relative path
                                    ContentType = file.ContentType,
                                    AccidentId = accident.AccidentId
                                };
                                 _context.accidentAttachments.Add(accidentAttachment);
                            }
                        }
                         await _context.SaveChangesAsync();
                    }
                    if (filess != null)
                    {
                        foreach (var file in filess)
                        {
                            // Validate file type and size
                            if (file.Length > 0 && file.Length <= 1048576) // 1 MB limit
                            {
                                var filePath = Path.Combine(_uploadFolderPath1, file.FileName);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }

                                var accidentPicAttachment = new AccidentPicAttachment
                                {
                                    FileName = file.FileName,
                                    FilePath = $"/AccidentPic/{file.FileName}", // Store the relative path
                                    ContentType = file.ContentType,
                                    AccidentId = accident.AccidentId
                                };
                                _context.accidentPicAttachments.Add(accidentPicAttachment);
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
       [HttpGet]
       public async Task<IActionResult> UpdateStatus(int id)
        {
            
            // Retrieve the car by its ID
            var accident = await _accidentService.GetAccidentById(id);
            if (accident == null)
            {
                return NotFound();
            }

            // Return the car to the view with the current status
            return View(accident);
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, bool isChecked)
        {
            var accident = await _accidentService.GetAccidentById(id);
            if (accident == null)
            {
                return NotFound();
            }

            // Update the Status based on checkbox value
            accident.AccidentStatus = isChecked ? 2 : 1;

            await _accidentService.UpdateAccident(accident);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DownloadAttachments(int Id)
        {

            var accident = await _context.Accidents
                .Include(w => w.accidentAttachment)
                .FirstOrDefaultAsync(w => w.AccidentId == Id);

            if (accident == null || !accident.accidentAttachment.Any())
            {
                return NotFound("No attachments found for this employee.");
            }

            var zipFileName = $"{accident.AccidentId}_Attachments.zip";
            var zipFilePath = Path.Combine(Path.GetTempPath(), zipFileName);

            using (var zipArchive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                foreach (var attachment in accident.accidentAttachment)
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImagesById(int id)
        {
            {
                var accident = await _context.Accidents
               .Include(w => w.accidentPicAttachment)
               .FirstOrDefaultAsync(w => w.AccidentId == id);

                if (accident == null || !accident.accidentPicAttachment.Any())
                {
                    return NotFound("No attachments found for this employee.");
                }

                // قائمة الصور التي سيتم عرضها
                var imageUrls = new List<string>();

                foreach (var attachment in accident.accidentPicAttachment)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", attachment.FilePath.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        string imageUrl = attachment.FilePath.StartsWith("AccidentPic/")
                ? "/" + attachment.FilePath.TrimStart('/')
                : "/" + attachment.FilePath.TrimStart('/');  // بناء المسار الصحيح

                        imageUrls.Add(imageUrl);
                    }
                }

                // إذا لم توجد صور لعرضها
                if (!imageUrls.Any())
                {
                    return NotFound("No images found for this employee.");
                }

                // عرض الصور في الصفحة
                return View(imageUrls);

            }

        }


    }
}
