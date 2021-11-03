using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ChatApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("ChatApplicationDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PrivateChat> PrivateChats { get; set; }
        public DbSet<PublicChat> PublicChats { get; set; }
    }
}
