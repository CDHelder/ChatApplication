using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.BuilderExtensions
{
    public class UserGroupChatConfiguration : EntityTypeConfiguration<UserGroupChat>
    {
        public UserGroupChatConfiguration()
        {
            ToTable("UserGroupChats");
            HasKey(x => x.Id);
            HasRequired(x => x.GroupChat).WithMany().HasForeignKey(x => x.GroupChatId);
            HasRequired(x => x.User).WithMany().HasForeignKey(x => x.ApplicationUserId);
            Property(x => x.UserGroupChatType).IsRequired();
        }
    }
}
