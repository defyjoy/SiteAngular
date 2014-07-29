using SiteAngular.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAngular.Core.Mapping
{
    public class StudentMap:EntityTypeConfiguration<Students>
    {
        public StudentMap()
        {
            HasKey(x => x.StudentGuid).Property(x => x.StudentGuid).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
