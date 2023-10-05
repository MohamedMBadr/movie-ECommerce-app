using eTickets.Data.Base.BaesInterFaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {

        public int Id { get; set; }
        [Display(Name = "Profile Picture ")]
        [Required(ErrorMessage = "Profile Picture is Required !!!!! ")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name  is Required !!!!! ")]
        [StringLength(50, MinimumLength =3 , ErrorMessage ="full Name must be between 3 and 50 chars")]

        public string FullName { get; set; }

        [Display(Name ="Biography")]
        [Required(ErrorMessage = " Biography  is Required !!!!! ")]

        public string Bio { get; set;}


        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
