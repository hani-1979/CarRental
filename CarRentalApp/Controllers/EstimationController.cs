using CarRentalApp.Models;
using CarRentalApp.Services;
using CarRentalApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers
{
    public class EstimationController : Controller
    {
        private readonly IEstimationService _estimationService;
        private readonly IUpdateStatusService _updateStatusService;

        public EstimationController(IEstimationService estimationService, IUpdateStatusService updateStatusService)
        {
            _estimationService = estimationService;
            _updateStatusService = updateStatusService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(int Id)
        {
            var model = new Estimation
            {
                AccidentId = Id,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Estimation estimation)
        {
            if (ModelState.IsValid)
            {
                Estimation est = new Estimation
                {
                    AccidentId = estimation.AccidentId,
                    EstimationNumber = estimation.EstimationNumber,
                    EstimationDate = estimation.EstimationDate,
                    EstimationSide = estimation.EstimationSide,
                    EstimationAmount = estimation.EstimationAmount,
                };
                await _estimationService.AddEstimation(estimation);
                await _updateStatusService.UpdateAccidentStatus(est.AccidentId);
                return RedirectToAction("Index","Accident");
            }
            return View();
        }
    
    }
}