using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarRentalApp.Models
{
    public class AccidentAttachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public int AccidentId { get; set; }
        [ValidateNever]
        public Accident? Accident { get; set; }
    }
}
