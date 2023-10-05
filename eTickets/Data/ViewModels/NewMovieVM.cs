using eTickets.Data.Base.BaesInterFaces;
using eTickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVM 
    {

        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name Is Required ")]
        public string Name  { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description Is Required ")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price Is Required ")]
        public double Price { get; set; }


        [Display(Name = "movie poster URL")]
        [Required(ErrorMessage = "poster Is Required ")]

        public string ImageURL { get; set; }


        [Display(Name = "Movie start Date ")]
        [Required(ErrorMessage = "Start Date Is Required ")]
        public DateTime StartDate { get; set; }
        [Display(Name = "movie End Date ")]
        [Required(ErrorMessage = "End Date Is Required ")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select a Category ")]
        [Required(ErrorMessage = "Moive Category Is Required ")]
        public MoiveCategory MoiveCategory { get; set; }

        [Display(Name = "Select one or many actor/s ")]
        [Required(ErrorMessage = "Actor Is Required ")]
        public List<int> ActorsIds { get; set; }
        [Display(Name = "Select a cinema ")]
        [Required(ErrorMessage = "Moive cinema Is Required ")]
        public int CinemaId { get; set; }

        [Display(Name = "Select a Producer ")]
        [Required(ErrorMessage = "Moive Producer Is Required ")]
        public int ProducerID { get; set; }
       
    }
}
