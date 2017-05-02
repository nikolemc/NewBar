using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using McStanleyBar.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace McStanleyBar.ViewModels
{
    public class EventsViewModel
    {
        public int Id { get; set; }
        public List<Events> Event { get; set; }
    }
}