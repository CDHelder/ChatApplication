using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.BuilderExtensions
{
    public class UserPublicChatConfiguration : EntityTypeConfiguration<UserPublicChat>
    {
        public UserPublicChatConfiguration()
        {
            ToTable("UserPublicChats");
            HasKey(t => t.Id);
            HasRequired(t => t.PublicChat).WithMany().HasForeignKey(t => t.PublicChatId);
            HasRequired(t => t.User).WithMany().HasForeignKey(t => t.ApplicationUserId);
        }
    }
}
