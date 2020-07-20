﻿using System.ComponentModel.DataAnnotations;

namespace ElectricShop.Infrastructure.Models
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }
    }
}