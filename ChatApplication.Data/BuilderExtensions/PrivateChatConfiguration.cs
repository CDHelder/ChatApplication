using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.BuilderExtensions
{
    public class PrivateChatConfiguration : EntityTypeConfiguration<PrivateChat>
    {
        public PrivateChatConfiguration()
        {
            ToTable("PrivateChats");
            HasKey(x => x.Id);
            HasMany(x => x.Messages).WithOptional().HasForeignKey(x => x.PrivateChatId);
            HasRequired(x => x.UserOne).WithMany().HasForeignKey(x => x.UserOneId).WillCascadeOnDelete(false);
            HasRequired(x => x.UserTwo).WithMany().HasForeignKey(x => x.UserTwoId).WillCascadeOnDelete(false);
        }
    }
}
