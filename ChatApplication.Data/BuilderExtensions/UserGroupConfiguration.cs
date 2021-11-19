using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.BuilderExtensions
{
    public class UserGroupConfiguration : EntityTypeConfiguration<UserGroup>
    {
        public UserGroupConfiguration()
        {
            ToTable("UserGroups");
            HasKey(t => t.Id);
            HasRequired(t => t.User).WithMany().HasForeignKey(t => t.UserId).WillCascadeOnDelete(false);
            HasRequired(t => t.Group).WithMany().HasForeignKey(t => t.GroupId);
        }
    }
}
