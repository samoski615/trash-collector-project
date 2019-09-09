using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Which day would you like to search?")]
        public DayOfWeek? PickupDay { get; set; }

        [Display(Name = "Confirm Pickup")]
        public bool ConfirmPickup { get; set; }

        [Display(Name = "Charges Applied")]
        public double Charges { get; set; }

        //public enum WeekDays
        //{
        //    Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        //}


        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}