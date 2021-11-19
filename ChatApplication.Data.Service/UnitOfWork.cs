using ChatApplication.Data.Service.Interfaces;
using ChatApplication.Data.Service.SpecificRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private UoFApplicationUserRepository _applicationUserRepository;
        private UoFMessageRepository _messageRepository;
        private UoFGroupRepository _groupRepository;
        private UoFUserGroupRepository _userGroupRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public UoFApplicationUserRepository ApplicationUserRepository 
        {
            get => _applicationUserRepository ?? new UoFApplicationUserRepository(_dbContext);
            private set => _applicationUserRepository = value;
        }
        public UoFMessageRepository MessageRepository 
        {
            get => _messageRepository ?? new UoFMessageRepository(_dbContext);
            private set => _messageRepository = value;
        }
        public UoFGroupRepository GroupRepository
        {
            get => _groupRepository ?? new UoFGroupRepository(_dbContext);
            private set => _groupRepository = value;
        }
        public UoFUserGroupRepository UserGroupRepository
        {
            get => _userGroupRepository ?? new UoFUserGroupRepository(_dbContext);
            private set => _userGroupRepository = value;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public bool SaveChanges()
        {
            var rowsChanged = _dbContext.SaveChanges();
            if (rowsChanged > 0)
                return true;

            return false;
        }
    }
}
