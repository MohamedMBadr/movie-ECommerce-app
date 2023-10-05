using eTickets.Data.Base.BaesInterFaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema :IEntityBase
    {
        public int Id { get; set; }


        [Display(Name ="Logo")]
        [Required(ErrorMessage = "Logo Picture is Required !!!!! ")]

        public string Logo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Cinema Name  is Required !!!!! ")]

        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema Description  is Required !!!!! ")]

        public string Description { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
