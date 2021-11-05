namespace ChatApplication.Data.Migrations
{
    using ChatApplication.Domain.Entities;
    using ChatApplication.Domain.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(ApplicationDbContext context)
        {
            string userId_1 = "9051c13b-6d91-4207-929b-9a35b8a44a1f";
            string userId_2 = "e2cbb030-f792-4075-aa70-6319bd5516aa";
            string userId_3 = "581b21c9-2254-4ee2-a793-a7fbcd6d7c8b";
            string userId_4 = "e9e9b88a-767e-4e19-bc80-59f84f819565";
            string userId_5 = "6d16d251-2c5e-42b5-90f6-188ab87fba3f";
            string userId_6 = "86ccdab9-6b04-4f6e-8229-33658420d037";

            string userPassword_1 = CreatePasswordHash("HenkHenk123!");
            string userPassword_2 = CreatePasswordHash("JaapJaap123!");
            string userPassword_3 = CreatePasswordHash("PietPiet123!");
            string userPassword_4 = CreatePasswordHash("JanJan123!");
            string userPassword_5 = CreatePasswordHash("ChrisChris123!");
            string userPassword_6 = CreatePasswordHash("DaanDaan123!");

            ApplicationUser[] users = new ApplicationUser[] {
                new ApplicationUser { Id = userId_1, Email = "Henk123@gmail.com", EmailConfirmed = true, UserName = "Henk123", PasswordHash = userPassword_1  },
                new ApplicationUser { Id = userId_2, Email = "Jaap123@gmail.com", EmailConfirmed = true, UserName = "Jaap123", PasswordHash = userPassword_2  },
                new ApplicationUser { Id = userId_3, Email = "Piet123@gmail.com", EmailConfirmed = true, UserName = "Piet123", PasswordHash = userPassword_3  },
                new ApplicationUser { Id = userId_4, Email = "Jan123@gmail.com", EmailConfirmed = true, UserName = "Jan123", PasswordHash = userPassword_4  }
            };

            ApplicationUser[] groupChatUsers = new ApplicationUser[]
            {
                new ApplicationUser { Id = userId_5, Email = "Chris123@gmail.com", EmailConfirmed = true, UserName = "Chris123", PasswordHash = userPassword_5  },
                new ApplicationUser { Id = userId_6, Email = "Daan123@gmail.com", EmailConfirmed = true, UserName = "Daan123", PasswordHash = userPassword_6  }
            };

            Message[] privateChatMessages = new Message[] {
                new Message { Id = 1, Content = "Private Chat Message Bericht 1", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 2, Content = "Private Chat Message Bericht 2", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 3, Content = "Private Chat Message Bericht 3", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 4, Content = "Private Chat Message Bericht 4", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 5, Content = "Private Chat Message Bericht 5", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 6, Content = "Private Chat Message Bericht 6", ReadByReciever = false, SendDate = DateTime.Today,}
            };

            Message[] publicChatMessages = new Message[] {
                new Message { Id = 7, Content = "Public Chat Message Bericht 1", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 8, Content = "Public Chat Message Bericht 2", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 9, Content = "Public Chat Message Bericht 3", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 10, Content = "Public Chat Message Bericht 4", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 11, Content = "Public Chat Message Bericht 5", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 12, Content = "Public Chat Message Bericht 6", ReadByReciever = false, SendDate = DateTime.Today,}
            };

            Message[] groupChatMessages = new Message[] {
                new Message { Id = 13, Content = "Group Chat Message Bericht 1", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 14, Content = "Group Chat Message Bericht 2", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 15, Content = "Group Chat Message Bericht 3", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 16, Content = "Group Chat Message Bericht 4", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 17, Content = "Group Chat Message Bericht 5", ReadByReciever = false, SendDate = DateTime.Today,},
                new Message { Id = 18, Content = "Group Chat Message Bericht 6", ReadByReciever = false, SendDate = DateTime.Today,}
            };

            context.PrivateChats.AddOrUpdate(x => x.Id
            ,new PrivateChat
            {
                Id = 1,
                UserOne = users[0],
                UserTwo = users[1],
                Messages = privateChatMessages.ToList()
            }); ;

            context.PublicChats.AddOrUpdate(x => x.Id
            ,new PublicChat
            {
                Id = 1,
                Name = "Publieke Chat 1",
                Description = "De publieke chat waarbij iedereen mag praten",
                Messages = publicChatMessages.ToList()
            });

            context.GroupChats.AddOrUpdate(x => x.Id
            ,new GroupChat
            {
                Id = 1,
                Name = "Groeps Chat 1",
                Description = "De groeps chat waarbij niet iedereen mag meekijken en meepraten",
                Users = groupChatUsers.ToList(),
                Messages = groupChatMessages.ToList()
            });

            context.Users.AddOrUpdate(x => x.Id, users);
            context.Users.AddOrUpdate(x => x.Id, groupChatUsers);

            context.Messages.AddOrUpdate(x => x.Id, privateChatMessages);
            context.Messages.AddOrUpdate(x => x.Id, publicChatMessages);
            context.Messages.AddOrUpdate(x => x.Id, groupChatMessages);

        }
        private string CreatePasswordHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            return pbkdf2.GetBytes(20).ToString();
        }
    }
}
