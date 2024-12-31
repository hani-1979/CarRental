using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarRentalApp.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchNameAr { get; set; }
        public string branchnameEn { get; set; }
        [ValidateNever]
        public ICollection<UserAccount> Users { get; set; }
    }
}
