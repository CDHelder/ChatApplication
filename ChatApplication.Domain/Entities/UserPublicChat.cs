using ChatApplication.Domain.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApplication.Domain.Entities
{
    public class UserPublicChat
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public int PublicChatId { get; set; }
        public PublicChat PublicChat { get; set; }
    }
}
