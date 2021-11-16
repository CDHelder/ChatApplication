using ChatApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.BuilderExtensions
{
    public class AdministratorConfiguration : EntityTypeConfiguration<Administrator>
    {
        public AdministratorConfiguration()
        {
            ToTable("Administrators");
        }
    }
}
