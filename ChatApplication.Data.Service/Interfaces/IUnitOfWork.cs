using ChatApplication.Data.Service.SpecificRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.Service.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UoFApplicationUserRepository ApplicationUserRepository { get; }
        UoFMessageRepository MessageRepository { get; }
        UoFGroupRepository GroupRepository { get; }
        UoFUserGroupRepository UserGroupRepository { get; }
        bool SaveChanges();
    }
}
