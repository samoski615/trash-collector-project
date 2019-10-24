using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AddressId { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string StateAbbreviation { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}