﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bileciki_ecommerce.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //relations
        public List<Movie> Movies { get; set; }
    }
}