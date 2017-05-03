﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace McStanleyBar.Models
{
    public class Events
    {
        
        public int Id { get; set; }
        public string Title { get; set;}

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime? StartTime { get; set; }

        public string Img { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genres Genre { get; set; }
        
        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        public virtual Venues Venue { get; set; }

        [NotMapped]
        public Guid TrackerId { get; set; } = Guid.NewGuid();

        public ICollection<Order> Orders { get; set; }



    }
}