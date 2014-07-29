using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAngular.Core.Models
{
    public class Students
    {
        [Required]
        public Guid StudentGuid { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        [Required]
        public string Phone { get; set; }

        public ICollection<Address> Addresses { get; set; }

    }
}
