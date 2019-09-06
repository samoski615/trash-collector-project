using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Monthly Balance")]
        public double MonthlyBalance { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Suspend Services")]
        [DataType(DataType.Date)]
        public string StartDate { get; set; }

        [Display(Name = "Resume Services")]
        [DataType(DataType.Date)]
        public string EndDate { get; set; }

        [Display(Name = "Weekly Pickup Day")]
        public WeekDays? PickupDay { get; set; }

        [Display(Name = "Additional Pickup Day")]
        [DataType(DataType.Date)]
        public string ExtraDate { get; set; }

        [Display(Name = "Month")]
        public string Month { get; set; }

        [Display(Name = "Day")]
        public string Day { get; set; }

        [Display(Name = "Year")]
        public string Year { get; set; }

        
        public enum WeekDays
        {
            Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        }


        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}