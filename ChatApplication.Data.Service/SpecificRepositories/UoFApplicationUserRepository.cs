using ChatApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.Service.SpecificRepositories
{
    public class UoFApplicationUserRepository : GenericRepository<ApplicationUser>
    {
        public UoFApplicationUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
