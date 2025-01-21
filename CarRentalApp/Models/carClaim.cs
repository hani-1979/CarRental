using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{

    public class carClaim
    {
        [Key]
        public int carClaimId { get; set; }
        public int AccidentId { get; set; }
        public int CarId { get; set; }
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public string carClaimNumber { get; set; }
        public int EstimationId { get; set; }  // Foreign Key to Estimation

        [ValidateNever]
        public virtual Estimation Estimation { get; set; }
        [ValidateNever]
        public Company company { get; set; }
        public decimal ClaimAmount {  get; set; }
         public DateTime ClaimDate {  get; set; }
        public int ClaimStatus { get; set; }
        
        [ValidateNever]
        public ICollection<ClaimAttachment> ClaimAttachments { get; set; } = new List<ClaimAttachment>();
        [ValidateNever]
        public ClaimStatus claimStatus { get; set; }
    }
}

