using ChatApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Domain.Entities
{
    public enum UserGroupChatType
    {
        User,
        Moderator
    }

    public class UserGroupChat
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public int GroupChatId { get; set; }
        public GroupChat GroupChat { get; set; }
        public UserGroupChatType UserGroupChatType { get; set; }
    }
}
