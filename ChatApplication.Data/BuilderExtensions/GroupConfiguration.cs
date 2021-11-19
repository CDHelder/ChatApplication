using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.BuilderExtensions
{
    public class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            ToTable("Groups");
            HasKey(t => t.Id);
            Property(t => t.GroupType).IsRequired();
            HasMany(t => t.Messages).WithRequired().HasForeignKey(t => t.GroupId);
        }
    }
}
