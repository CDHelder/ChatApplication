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
            HasMany<UserGroupChat>(a => a.UserGroupChats).WithRequired(a => a.User).HasForeignKey(a => a.ApplicationUserId);
            HasMany<UserPublicChat>(a => a.UserPublicChats).WithRequired(a => a.User).HasForeignKey(a => a.ApplicationUserId);
            HasMany<Message>(a => a.Messages).WithRequired(a => a.Sender).HasForeignKey(a => a.SenderId);
        }
    }
}
