using ChatApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Domain.Entities
{
    public enum GroupUserType
    {
        User,
        Moderator
    }
    public class UserGroup
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public GroupUserType GroupUserType { get; set; }
    }
}
