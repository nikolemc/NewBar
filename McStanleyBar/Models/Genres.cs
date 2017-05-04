using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace McStanleyBar.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Events> Events { get; set; } = new HashSet<Events>();


    }
}