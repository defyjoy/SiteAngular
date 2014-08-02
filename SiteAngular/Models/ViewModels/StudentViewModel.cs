using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteAngular.Models.ViewModels
{
    public class StudentViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public string Phone { get; set; }

        [Display(Name = "Building")]
        public string Building { get; set; }

        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name="Landmark")]
        public string LandMark { get; set; }

        [Display(Name = "District")]
        public string District { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

    }
}