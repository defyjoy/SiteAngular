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
        [Display(Name="First Name")]
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
    }
}