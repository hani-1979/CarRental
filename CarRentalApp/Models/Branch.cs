using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace CarRentalApp.Models
{
    public class Branch
    {
        [DisplayName("رقم الفرع ")]
        public int BranchId { get; set; }
        [DisplayName("إسم الفرع عربي")]
        public string BranchNameAr { get; set; }
        [DisplayName("إسم الفرع إنجليزي")]
        public string branchnameEn { get; set; }
        [ValidateNever]
        public ICollection<UserAccount> Users { get; set; }
    }
}
