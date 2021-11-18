﻿using ChatApplication.Data.Service.Interfaces;
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
        private UoFGroupChatRepository _groupChatRepository;
        private UoFMessageRepository _messageRepository;
        private UoFPrivateChatRepository _privateChatRepository;
        private UoFPublicChatRepository _publicChatRepository;
        private UoFUserPublicChatRepository _userPublicChatRepository;
        private UoFUserGroupChatRepository _userGroupChatRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //TODO: VERVANG DIE ALLE FKING GROEPSOORTEN MODELS MET GROUP REPOSITORY 
        public UoFApplicationUserRepository ApplicationUserRepository 
        {
            get => _applicationUserRepository ?? new UoFApplicationUserRepository(_dbContext);
            private set => _applicationUserRepository = value;
        }
        public UoFGroupChatRepository GroupChatRepository 
        {
            get => _groupChatRepository ?? new UoFGroupChatRepository(_dbContext);
            private set => _groupChatRepository = value;
        }
        public UoFMessageRepository MessageRepository 
        {
            get => _messageRepository ?? new UoFMessageRepository(_dbContext);
            private set => _messageRepository = value;
        }
        public UoFPrivateChatRepository PrivateChatRepository 
        {
            get => _privateChatRepository ?? new UoFPrivateChatRepository(_dbContext);
            private set => _privateChatRepository = value;
        }
        public UoFPublicChatRepository PublicChatRepository 
        {
            get => _publicChatRepository ?? new UoFPublicChatRepository(_dbContext);
            private set => _publicChatRepository = value;
        }
        public UoFUserPublicChatRepository UserPublicChatRepository
        {
            get => _userPublicChatRepository ?? new UoFUserPublicChatRepository(_dbContext);
            private set => _userPublicChatRepository = value;
        }
        public UoFUserGroupChatRepository UserGroupChatRepository
        {
            get => _userGroupChatRepository ?? new UoFUserGroupChatRepository(_dbContext);
            private set => _userGroupChatRepository = value;
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
