using eTickets.Data.Base.BaesInterFaces;
using eTickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name  { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MoiveCategory MoiveCategory { get; set; }


        public List<Actor_Movie> Actors_Movies { get; set; }

        public int CinemaId { get; set; }
        [ForeignKey(nameof(CinemaId))]
        public Cinema Cinema { get; set; }


        public int ProducerID { get; set; }
        [ForeignKey(nameof(ProducerID))]
        public Producer  Producer { get; set; }
    }
}
