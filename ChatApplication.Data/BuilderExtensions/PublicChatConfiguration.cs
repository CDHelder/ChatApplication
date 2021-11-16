using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.BuilderExtensions
{
    public class PublicChatConfiguration : EntityTypeConfiguration<PublicChat>
    {
        public PublicChatConfiguration()
        {
            ToTable("PublicChats");
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired();
            HasMany(x => x.Messages).WithOptional().HasForeignKey(x => x.PublicChatId);
        }
    }
}
