using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarRentalApp.Models
{
    public class ClaimAttachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public int carClaimId { get; set; }
        [ValidateNever]
        public carClaim? carClaim { get; set; }
    }
}
