using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.Service.SpecificRepositories
{
    public class UoFPublicChatRepository : GenericRepository<PublicChat>
    {
        public UoFPublicChatRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
