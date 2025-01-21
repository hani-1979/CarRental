using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.ViewModels
{
    [Keyless]
    public class RegistrationViewModel
    {
        [Key]
        public int userId { get; set; }
        [DisplayName("البريد الألكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName Is Required")]
        [MaxLength(20, ErrorMessage = "Max 20 Charcter is Alowed")]
        [DisplayName("إسم المستخدم")]
        public string UserName { get; set; }
        [DisplayName("إسم الفرع")]
        [ValidateNever]
        public string BranchNameAr { get; set; }
        [DisplayName("إسم الفرع")]
        public int? BranchId { get; set; }
        [ValidateNever]
        [DisplayName("إسم الفرع")]
        public Branch? Branch { get; set; }
        [ValidateNever]
        public List<Branch> branches { get; set; }
        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = "مطلوبة")]
        [DataType(DataType.Password)]
        [DisplayName("كلمة المرور")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Please Confirm Your Password")]

        [DataType(DataType.Password)]
        [DisplayName("أعد كلمة المرور")]
        public string ConfirmPassword { get; set; }
    }
}
