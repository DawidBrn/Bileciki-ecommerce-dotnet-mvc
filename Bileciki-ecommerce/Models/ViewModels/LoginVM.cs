using System.ComponentModel.DataAnnotations;

namespace Bileciki_ecommerce.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "E-mail adress")]
        public string EmailAdress { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
