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
        UoFGroupChatRepository GroupChatRepository { get; }
        UoFMessageRepository MessageRepository { get; }
        UoFPrivateChatRepository PrivateChatRepository { get; }
        UoFPublicChatRepository PublicChatRepository { get; }
        bool SaveChanges();
    }
}
