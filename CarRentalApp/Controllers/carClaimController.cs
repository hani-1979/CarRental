using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Services;
using CarRentalApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.IO.Compression;
using System.Security.Claims;
using static Azure.Core.HttpHeader;

namespace CarRentalApp.Controllers
{
    public class carClaimController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBranchService _branchService;
        private readonly IUpdateStatusService _updateStatusService;
        private readonly IEstimationService _estimationService;
        private readonly ICarClaimService _carClaimService;
        private readonly IAccidentService _accidentService;
        private readonly ICompanyService _companyService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ICarService _carService;
        private readonly string _uploadFolderPath;

        public carClaimController(AppDbContext context,IBranchService branchService, IWebHostEnvironment hostEnvironment, IHostEnvironment environment, IUpdateStatusService updateStatusService, IEstimationService estimationService, ICarClaimService carClaimService, IAccidentService accidentService, ICompanyService companyService, ICarService carService)
        {
            _context = context;
            _branchService = branchService;
            _updateStatusService = updateStatusService;
            _estimationService = estimationService;
            _carClaimService = carClaimService;
            _accidentService = accidentService;
            _companyService = companyService;
            _carService = carService;
            _hostEnvironment = hostEnvironment;
            _uploadFolderPath = Path.Combine(environment.ContentRootPath, "wwwroot", "CarClaim");
            if (!Directory.Exists(_uploadFolderPath))
            {
                Directory.CreateDirectory(_uploadFolderPath);
            }
        }
        public async Task<IActionResult> Index()
        {
            var accidentData = from carClaim in _context.carClaim
                               join Accident in _context.Accidents on carClaim.AccidentId equals Accident.AccidentId
                               join car in _context.Cars on carClaim.CarId equals car.CarId
                               join company in _context.Companys on Accident.CompanyId equals company.CompanyId
                               join Estimation in _context.Estimations on carClaim.EstimationId equals Estimation.EstimationId
                               join ClaimStatus in _context.ClaimStatuses on carClaim.carClaimId equals ClaimStatus.carClaimId
                               select new AccidentClaimViewModel
                               {

                                   carClaimId = carClaim.carClaimId,
                                   EstimationNumber=Estimation.EstimationNumber,
                                   AccidentNumber=Accident.AccidentNumber,
                                   Percentage=Accident.Percentage,
                                   DriverName =Accident.DriverName,
                                   DriveLicence=Accident.DriveLicence,
                                   DriverIdentity=Accident.DriverIdentity,
                                   AccidentId = carClaim.AccidentId,
                                   CarId = carClaim.CarId,
                                   ChassisNumber = car.ChassisNumber,
                                   PlateNumber = car.PlateNumber,
                                   CompanyNameAr = company.CompanyNameAr,
                                   ClaimAmount = carClaim.ClaimAmount,
                                   StatusCode = ClaimStatus.StatusCode,
                                   carClaimNumber=carClaim.carClaimNumber
                               };

            // Execute the query and get the results
            var resultList = accidentData.ToList();

            return View(accidentData);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var model = new AccidentClaimViewModel
            {
                AccidentId = Id,
                EstimationId = (int)await _estimationService.GetEstIdByAccidentIdAsync(Id),
                CarId = (int)await _accidentService.GetCarIdByAccidentIdAsync(Id),
                CompanyId = (int)await _companyService.GetCompanyByAccidentIdAsync(Id),
                BranchId=(int)await _branchService.GetBranchByCarIdAsync(Id),

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccidentClaimViewModel model, List<IFormFile> files)
        {
            try
            {

                if (ModelState.IsValid)

                {
                    // string uniqueFileName = ProcessUplodedFile(model);
                    carClaim carclaim = new carClaim()
                    {
                        EstimationId = model.EstimationId,
                        BranchId = model.BranchId,
                        carClaimId = model.carClaimId,
                        carClaimNumber = model.carClaimNumber,
                        AccidentId = model.AccidentId,
                        CarId = model.CarId,
                        CompanyId = model.CompanyId,
                        ClaimAmount = model.ClaimAmount,
                        ClaimDate = model.ClaimDate,
                        ClaimStatus = 1,

                        // PhothPath = uniqueFileName
                    };

                    await _carClaimService.AddClaim(carclaim);
                    var status = new ClaimStatus
                    {

                        carClaimId = carclaim.carClaimId,
                        StatusCode = 0,
                        Comment = ""


                    };


                    await _context.ClaimStatuses.AddAsync(status);
                   



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

                                var ClaimAttachments = new ClaimAttachment
                                {
                                    FileName = file.FileName,
                                    FilePath = $"/CarClaim/{file.FileName}", // Store the relative path
                                    ContentType = file.ContentType,
                                    carClaimId = carclaim.carClaimId,
                                };
                                _context.ClaimAttachments.Add(ClaimAttachments);
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
        [HttpGet]
        public async Task<IActionResult> ChangeStatus(int carClaimId)
        {
            ViewBag.carClaimId = carClaimId;
            var accidentId = _context.carClaim
                              .Where(a => a.carClaimId == carClaimId)
                              .Select(a => a.AccidentId)
                              .FirstOrDefault();
            ViewBag.accidentId = accidentId;
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(AccidentClaimViewModel model,int carClaimId,int accidentId, int statusCode, string comment,IFormFile file)
        {
            try
            {
               
                var claim = await _context.ClaimStatuses.FirstOrDefaultAsync(c => c.carClaimId == carClaimId);
                if (claim == null)
                {
                    return NotFound();
                }

                // Update the claim's status and comment
                claim.StatusCode = statusCode;
                claim.Comment = comment;

                if (statusCode == 3 && model.Photo != null && model.Photo.Length > 0)  
                    {
                    var filePath = Path.Combine(_hostEnvironment.WebRootPath, "CarClaim", model.Photo.FileName);


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Photo.CopyToAsync(fileStream);
                    }


                    var claimattachment = new ClaimAttachment
                    {
                        FileName = model.Photo.FileName,
                        FilePath = filePath,
                        ContentType = model.Photo.ContentType,
                        carClaimId = model.carClaimId

                    };


                    await _context.ClaimAttachments.AddAsync(claimattachment);
                    await _updateStatusService.UpdatAgreeAccident(accidentId);
                }

                    _context.Update(claim);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","carClaim");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the process
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return RedirectToAction("ChangeStatus", new { carClaimId = carClaimId });
            }
        }
        [HttpGet]
        public async Task<IActionResult> DownloadAttachments(int Id)
        {

            var carClaim = await _context.carClaim
               .Include(w => w.ClaimAttachments)
               .FirstOrDefaultAsync(w => w.carClaimId == Id);


            if (carClaim == null || !carClaim.ClaimAttachments.Any())
            {
                return NotFound("No attachments found for this employee.");
            }

            var zipFileName = $"{carClaim.carClaimId}_Attachments.zip";
            var zipFilePath = Path.Combine(Path.GetTempPath(), zipFileName);

            using (var zipArchive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                foreach (var attachment in carClaim.ClaimAttachments)
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
    }
    }
    
