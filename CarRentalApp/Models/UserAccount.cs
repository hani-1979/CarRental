using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class UserAccount
    {
        [Key]
        public int userId { get; set; }
        [Required(ErrorMessage = "UserName Is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

        // Link each user to a specific branch
        public int BranchId { get; set; }
        [ValidateNever]
        public Branch? Branch { get; set; }
        public bool IsAdmin { get; set; }
    }
}
