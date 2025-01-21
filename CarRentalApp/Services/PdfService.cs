using DinkToPdf.Contracts;
using DinkToPdf;

namespace CarRentalApp.Services
{
    public class PdfService
    {
        private readonly IConverter _converter;

        public PdfService()
        {
            _converter = new BasicConverter(new PdfTools());
        }

        public byte[] GeneratePdfFromHtml(string htmlContent)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Out = null  // Keep it in memory, not in a file
            },
                Objects = {
                new ObjectSettings() {
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            return _converter.Convert(doc);
        }
    }
}
