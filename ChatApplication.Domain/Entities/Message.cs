﻿using ChatApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Domain.Entities
{
    //TODO: Maak alle ids in de objecten en Fluent API
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public bool ReadByReciever { get; set; }
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public int? GroupChatId { get; set; }
        public int? PrivateChatId { get; set; }
        public int? PublicChatId { get; set; }
    }
}
