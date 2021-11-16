using ChatApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Domain.Entities
{
    public class PrivateChat
    {
        public int Id { get; set; }
        public List<Message> Messages { get; set; }
        public string UserOneId { get; set; }
        public ApplicationUser UserOne { get; set; }
        public string UserTwoId { get; set; }
        public ApplicationUser UserTwo { get; set; }
    }
}
