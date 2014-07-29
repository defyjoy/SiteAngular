using SiteAngular.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAngular.Database.Migration
{
    public class SiteAngularContext:DbContext
    {
        public SiteAngularContext():base("AngularContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Remove<PluralizingTableNameConvention>();
            builder.Configurations.AddFromAssembly(typeof(StudentMap).Assembly);
            base.OnModelCreating(builder);;
        }
    }
}
