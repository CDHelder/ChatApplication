using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.BuilderExtensions
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            HasMany(a => a.Messages).WithRequired().HasForeignKey(a => a.UserId).WillCascadeOnDelete(false);
        }
    }
}
