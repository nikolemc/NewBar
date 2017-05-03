using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using McStanleyBar.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace McStanleyBar.ViewModels
{
    public class HomePageViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Events> Event { get; set; }
        public Order ShoppingCart { get; set; }
    }
}