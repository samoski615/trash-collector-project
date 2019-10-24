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

        [Display(Name = "Weekly Balance")]
        public string WeeklyCharges { get; set; }

        [Display(Name = "Monthly Balance")]
        public double MonthlyBalance { get; set; }

        [Display(Name = "Suspend Services")]
        [DataType(DataType.Date)]
        public string StartDate { get; set; }

        [Display(Name = "Resume Services")]
        [DataType(DataType.Date)]
        public string EndDate { get; set; }

        [Display(Name = "Weekly Pickup Day")]
        public DayOfWeek? DayOfWeek { get; set; }

        [Display(Name = "Additional Pickup Day")]
        [DataType(DataType.Date)]
        public string ExtraDate { get; set; }

        [Display(Name = "Confirm Pickup")]
        public bool ConfirmPickup { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
   
}