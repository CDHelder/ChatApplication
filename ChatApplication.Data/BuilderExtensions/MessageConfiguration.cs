using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.BuilderExtensions
{
    public class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
            ToTable("Messages");
            HasKey(x => x.Id);
            HasRequired(x => x.Sender).WithMany().HasForeignKey(x => x.SenderId).WillCascadeOnDelete(true);
            Property(x => x.Content).IsRequired();
        }
    }
}