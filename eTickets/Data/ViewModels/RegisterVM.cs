using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eTickets.Data.ViewModels
{
    public class RegisterVM
    {


        [Required(ErrorMessage = "Full name Required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "confirmPassword is Required")]
        [DataType(DataType.Password)]
        [Compare("Password" ,ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
