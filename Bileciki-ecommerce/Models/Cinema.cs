using Bileciki_ecommerce.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bileciki_ecommerce.Models
{
    public class Cinema :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo of the cinema")]
        [Required(ErrorMessage = "this field is required")]
        public string Logo { get; set; }
        [Display(Name = "Name of the cinema")]
        [Required(ErrorMessage = "this field is required")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "this field is required")]
        public string Description { get; set; }

        //relations
        public List<Movie> Movies { get; set; }
    }
}
