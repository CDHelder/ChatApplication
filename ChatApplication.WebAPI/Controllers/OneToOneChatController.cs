using ChatApplication.Business;
using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Identity;
using ChatApplication.WebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ChatApplication.WebAPI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/OneToOne")]
    public class OneToOneChatController : ApiController
    {
        private GroupService groupService;

        public OneToOneChatController()
        {
            groupService = new GroupService();
        }

        [HttpGet, Route("All")]
        public List<GroupViewModel> GetAllPublicGroups()
        {
            var groups = groupService.GetAllGroups(GroupType.OneToOne);
            var viewmodel = new List<GroupViewModel>();

            foreach (var group in groups)
                viewmodel.Add(new GroupViewModel { Group = group, Users = MapUsers(groupService.GetGroupUsers(group.Id)) });

            return viewmodel;
        }

        [HttpGet, Route("{id}")]
        public GroupViewModel GetPublicGroup(int id)
        {
            var group = groupService.GetGroup(id, GroupType.OneToOne);
            var users = groupService.GetGroupUsers(id);

            //TODO: Vervang door AutoMapper
            List<UserViewModel> usersVM = MapUsers(users);

            return new GroupViewModel { Group = group, Users = usersVM };
        }

        private static List<UserViewModel> MapUsers(List<ApplicationUser> users)
        {
            var usersVM = new List<UserViewModel>();
            foreach (var user in users)
            {
                usersVM.Add(new UserViewModel { Email = user.Email, UserName = user.UserName, Id = user.Id });
            }

            return usersVM;
        }
    }
}