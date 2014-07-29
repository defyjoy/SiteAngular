using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAngular.Core.Models
{
    public class Address
    {
        public Guid AddressGuid { get; set; }
        public Guid StudentGuid { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string LandMark { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Students Student { get; set; }

    }
}
