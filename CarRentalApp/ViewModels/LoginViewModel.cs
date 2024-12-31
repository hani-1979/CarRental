using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CarRentalApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName Is Required")]
        [DisplayName("أسم المستخدم أو الإيميل")]

        [DataType(DataType.Password)]
        public string UserNameOrEmail { get; set; }
        [Compare("Password", ErrorMessage = "Please Confirm Your Password")]
        [DisplayName("كلمة المرور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int userI { get; set; }
    }
}
