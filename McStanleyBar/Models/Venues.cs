using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace McStanleyBar.Models
{
    public class Venues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CapacitySize { get; set; }


        public virtual ICollection<Events> Events { get; set; } = new HashSet<Events>();


    }
}