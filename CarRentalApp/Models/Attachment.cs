using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarRentalApp.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public int InsuranceId { get; set; }
        [ValidateNever]
        public Insurance? insurance { get; set; }
    }
}
