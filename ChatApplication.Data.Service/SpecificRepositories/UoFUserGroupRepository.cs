using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.Service.SpecificRepositories
{
    public class UoFUserGroupRepository : GenericRepository<UserGroup>
    {
        public UoFUserGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
