using ChatApplication.Data.BuilderExtensions;
using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace ChatApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("ChatApplicationDbContext-2.0", throwIfV1Schema: false)
        {
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            builder.Conventions.Remove<ForeignKeyIndexConvention>();
        }
    }
}
