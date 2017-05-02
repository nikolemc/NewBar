﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace McStanleyBar.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Title { get; set;}
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genres Genre { get; set; }
        
        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        public virtual Venues Venue { get; set; }
        
    }
}