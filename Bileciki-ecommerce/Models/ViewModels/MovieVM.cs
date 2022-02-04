using Bileciki_ecommerce.Data;
using Bileciki_ecommerce.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bileciki_ecommerce.Models.ViewModels
{
    public class MovieVM
    {
        [Display(Name ="Movie name")]
        [Required(ErrorMessage ="This field is required")]
        public string Name { get; set; }
        [Display(Name = "Movie desc.")]
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "This field is required")]
        public double Price { get; set; }
        [Display(Name = "Poster URL")]
        [Required(ErrorMessage = "This field is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Start date")]
        [Required(ErrorMessage = "This field is required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "end date")]
        [Required(ErrorMessage = "This field is required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select category")]
        [Required(ErrorMessage = "This field is required")]
        public MovieCategory MovieCategory { get; set; }

        //relations
        [Display(Name = "Select actors")]
        [Required(ErrorMessage = "This field is required")]
        public List<int> ActorsId { get; set; }

        //cinema
        [Display(Name = "Select cinema")]
        [Required(ErrorMessage = "This field is required")]
        public int CinemaId { get; set; }

        //producer
        [Display(Name = "Select producers")]
        [Required(ErrorMessage = "This field is required")]
        public int ProducerId { get; set; }
       
    }

}
