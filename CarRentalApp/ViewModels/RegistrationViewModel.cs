using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.ViewModels
{
    [Keyless]
    public class RegistrationViewModel
    {
        [Key]
        public int userId { get; set; }
        
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName Is Required")]
        [MaxLength(20, ErrorMessage = "Max 20 Charcter is Alowed")]
        public string UserName { get; set; }
        public int? BranchId { get; set; }
        [ValidateNever]
        public Branch? Branch { get; set; }
        [ValidateNever]
        public List<Branch> branches { get; set; }
        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Please Confirm Your Password")]

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
