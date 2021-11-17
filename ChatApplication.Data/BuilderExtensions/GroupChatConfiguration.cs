using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.BuilderExtensions
{
    public class GroupChatConfiguration : EntityTypeConfiguration<GroupChat>
    {
        public GroupChatConfiguration()
        {
            ToTable("GroupChats");
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired();
            HasMany(x => x.Messages).WithOptional().HasForeignKey(x => x.GroupChatId);
            HasMany(x => x.UserGroupChats).WithRequired(x => x.GroupChat).HasForeignKey(x => x.GroupChatId);
        }
    }
}
