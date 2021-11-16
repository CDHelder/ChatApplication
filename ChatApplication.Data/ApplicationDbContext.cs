using ChatApplication.Data.BuilderExtensions;
using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Reflection;

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
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<UserGroupChat> UserGroupChats { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
