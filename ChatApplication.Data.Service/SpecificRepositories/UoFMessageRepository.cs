using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.Service.SpecificRepositories
{
    public class UoFMessageRepository : GenericRepository<Message>
    {
        public UoFMessageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
