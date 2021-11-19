using ChatApplication.Data;
using ChatApplication.Data.Service;
using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Business
{
    public class GroupService
    {
        private UnitOfWork unitOfWork;

        public Group GetGroup(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                unitOfWork = new UnitOfWork(context);

                var group = unitOfWork.GroupRepository.GetById(id);

                group.Messages = unitOfWork.MessageRepository.GetAll(filter: x => x.GroupId == id);

                return group;
            }
        }

        public Group GetGroup(int id, GroupType groupType)
        {
            using (var context = new ApplicationDbContext())
            {
                unitOfWork = new UnitOfWork(context);

                var group = unitOfWork.GroupRepository.GetById(id);

                group.Messages = unitOfWork.MessageRepository.GetAll(filter: x => x.GroupId == id);

                if (group.GroupType == groupType)
                    return group;

                return null;
            }
        }

        public List<ApplicationUser> GetGroupUsers(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                unitOfWork = new UnitOfWork(context);

                var userIds = unitOfWork.UserGroupRepository.GetAll(filter: x => x.GroupId == id).Select(x => x.UserId);

                var users = unitOfWork.ApplicationUserRepository.GetAll(filter: x => userIds.Contains(x.Id));

                return users;
            }
        }

        public List<Group> GetAllGroups()
        {
            using (var context = new ApplicationDbContext())
            {
                unitOfWork = new UnitOfWork(context);

                var groups = unitOfWork.GroupRepository.GetAll();

                foreach (var group in groups)
                {
                    group.Messages = unitOfWork.MessageRepository.GetAll(filter: x => x.GroupId == group.Id);
                }

                return groups;
            }
        }

        public List<Group> GetAllGroups(GroupType groupType)
        {
            using (var context = new ApplicationDbContext())
            {
                unitOfWork = new UnitOfWork(context);

                var groups = unitOfWork.GroupRepository.GetAll(filter: x => x.GroupType == groupType);

                foreach (var group in groups)
                {
                    group.Messages = unitOfWork.MessageRepository.GetAll(filter: x => x.GroupId == group.Id);
                }

                return groups;
            }
        }
    }
}
