using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bileciki_ecommerce.Models.Indentity
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name ="Full name")]
        public string Fullname { get; set; }
    }
}
