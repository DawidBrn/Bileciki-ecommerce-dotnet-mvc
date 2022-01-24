using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bileciki_ecommerce.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string Fullname { get; set; }
        public string Bio { get; set; }

        //relations
        public List<Movie> Movies { get; set; }


    }
}
