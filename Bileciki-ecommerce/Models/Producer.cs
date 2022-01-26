using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bileciki_ecommerce.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile picture")]
        [Required(ErrorMessage = "this field is required")]

        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "this field is required")]

        public string Fullname { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "this field is required")]

        public string Bio { get; set; }

        //relations
        public List<Movie> Movies { get; set; }


    }
}
