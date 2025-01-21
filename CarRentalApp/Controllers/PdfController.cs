using CarRentalApp.Models;
using CarRentalApp.Services;
using CarRentalApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CarRentalApp.Controllers
{
    
    public class PdfController : Controller
    {
        private readonly PdfService _pdfService;

        public PdfController(PdfService pdfService)
        {
            _pdfService = pdfService;
        }
        public IActionResult Details(int id)
        {
            // Replace this with logic to get the accident data from the database
            var model = GetAccidentById(id); // Your method to fetch accident details from DB

            return View(model); // Return the details view
        }

        public IActionResult GeneratePdf(int id)
        {
            // Fetch the accident details by ID (from DB or data source)
            var model = GetAccidentById(id); // Fetch the model here

            // Render the HTML content for the details view
            var htmlContent = RenderViewToString("Details", model);

            // Generate PDF from the HTML
            var pdf = _pdfService.GeneratePdfFromHtml(htmlContent);

            // Return the PDF as a downloadable file
            return File(pdf, "application/pdf", "AccidentDetails.pdf");
        }

        private string RenderViewToString(string viewName, object model)
        {
            var controllerContext = new ActionContext(HttpContext, RouteData, ControllerContext.ActionDescriptor);

            // Use ViewEngine to find the view, similar to the original approach.
            var viewEngine = HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
            var viewResult = viewEngine.FindView(controllerContext, viewName, false);

            if (!viewResult.Success)
            {
                throw new InvalidOperationException($"View '{viewName}' not found.");
            }

            using (var sw = new StringWriter())
            {
                // Create a ViewDataDictionary (this is where we put the model data)
                var viewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(
                    controllerContext,
                    viewResult.View,
                    viewData,
                    new TempDataDictionary(HttpContext, (ITempDataProvider)TempData),sw,
                    new HtmlHelperOptions()
                );

                viewResult.View.RenderAsync(viewContext).Wait();  // Render the view
                return sw.ToString();  // Return the rendered HTML string
            }
        }
        // Example method to get accident details (replace with actual DB logic)
        private AccidentClaimViewModel GetAccidentById(int id)
        {
            return new AccidentClaimViewModel
            {
                carClaimId = id,
                carClaimNumber = "500"
               
            };
        }
    }
}

