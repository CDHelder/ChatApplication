using ChatApplication.Business;
using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Identity;
using ChatApplication.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatApplication.WebAPI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Groups")]
    public class GroupController : ApiController
    {
        private readonly GroupService groupService;

        public GroupController()
        {
            groupService = new GroupService();
        }

        [HttpGet, Route("{id}")]
        public GroupViewModel GetGroup(int id)
        {
            var group = groupService.GetGroup(id);
            var users = groupService.GetGroupUsers(id);

            //TODO: Vervang door AutoMapper
            List<UserViewModel> usersVM = MapUsers(users);

            return new GroupViewModel { Group = group, Users = usersVM };
        }

        public static List<UserViewModel> MapUsers(List<ApplicationUser> users)
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
