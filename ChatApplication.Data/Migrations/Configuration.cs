namespace ChatApplication.Data.Migrations
{
    using ChatApplication.Business;
    using ChatApplication.Domain.Entities;
    using ChatApplication.Domain.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private HashingService hashingService;
        public Configuration()
        {
            hashingService = new HashingService();
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

            string userSalt_1 = hashingService.CreateSalt();
            string userSalt_2 = hashingService.CreateSalt();
            string userSalt_3 = hashingService.CreateSalt();
            string userSalt_4 = hashingService.CreateSalt();
            string userSalt_5 = hashingService.CreateSalt();
            string userSalt_6 = hashingService.CreateSalt();

            string userPassword_1 = hashingService.CreatePasswordHash("HenkHenk123!", userSalt_1);
            string userPassword_2 = hashingService.CreatePasswordHash("JaapJaap123!", userSalt_2);
            string userPassword_3 = hashingService.CreatePasswordHash("PietPiet123!", userSalt_3);
            string userPassword_4 = hashingService.CreatePasswordHash("JanJan123!", userSalt_4);
            string userPassword_5 = hashingService.CreatePasswordHash("ChrisChris123!", userSalt_5);
            string userPassword_6 = hashingService.CreatePasswordHash("DaanDaan123!", userSalt_6);

            ApplicationUser[] users = new ApplicationUser[] {
                new ApplicationUser { Id = userId_1, Email = "Henk123@gmail.com", EmailConfirmed = true, UserName = "Henk123", PasswordHash = userPassword_1, Salt = userSalt_1 },
                new ApplicationUser { Id = userId_2, Email = "Jaap123@gmail.com", EmailConfirmed = true, UserName = "Jaap123", PasswordHash = userPassword_2, Salt = userSalt_2 },
                new ApplicationUser { Id = userId_3, Email = "Piet123@gmail.com", EmailConfirmed = true, UserName = "Piet123", PasswordHash = userPassword_3, Salt = userSalt_3  },
                new ApplicationUser { Id = userId_4, Email = "Jan123@gmail.com", EmailConfirmed = true, UserName = "Jan123", PasswordHash = userPassword_4, Salt = userSalt_4  }
            };

            ApplicationUser[] groupChatUsers = new ApplicationUser[]
            {
                new ApplicationUser { Id = userId_5, Email = "Chris123@gmail.com", EmailConfirmed = true, UserName = "Chris123", PasswordHash = userPassword_5, Salt = userSalt_5  },
                new ApplicationUser { Id = userId_6, Email = "Daan123@gmail.com", EmailConfirmed = true, UserName = "Daan123", PasswordHash = userPassword_6, Salt = userSalt_6  }
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
            , new PrivateChat
            {
                Id = 1,
                UserOne = users[0],
                UserOneId = users[0].Id,
                UserTwo = users[1],
                UserTwoId = users[1].Id,
                Messages = privateChatMessages.ToList()
            }); ;

            context.PublicChats.AddOrUpdate(x => x.Id
            , new PublicChat
            {
                Id = 1,
                Name = "Publieke Chat 1",
                Description = "De publieke chat waarbij iedereen mag praten",
                Messages = publicChatMessages.ToList()
            });

            var groupChat1 = new GroupChat
            {
                Id = 1,
                Name = "Groeps Chat 1",
                Description = "De groeps chat waarbij niet iedereen mag meekijken en meepraten",
                Groupmoderator = users[2],
                GroupmoderatorId = users[2].Id,
                Password = null,
                Messages = groupChatMessages.ToList()
            };

            var userGroupChats1 = new UserGroupChat[]
            { 
                new UserGroupChat
                {
                    GroupChat = groupChat1,
                    GroupChatId = groupChat1.Id,
                    User = groupChatUsers[0],
                    UserId = groupChatUsers[0].Id
                }
            };

            context.GroupChats.AddOrUpdate(x => x.Id, groupChat1);

            context.UserGroupChats.AddOrUpdate(x => x.Id, userGroupChats1);

            context.Users.AddOrUpdate(x => x.Id, users);

            context.Messages.AddOrUpdate(x => x.Id, privateChatMessages);
            context.Messages.AddOrUpdate(x => x.Id, publicChatMessages);
            context.Messages.AddOrUpdate(x => x.Id, groupChatMessages);

            //Create Admin

            string adminSalt = hashingService.CreateSalt();
            string adminPassword = hashingService.CreatePasswordHash("Adminadmin123!", adminSalt);

            Administrator admin = new Administrator
            {
                Id = "08a1f26d-c8db-49b5-90c1-60f2015abbe9",
                Email = "Admin123@gmail.com",
                EmailConfirmed = true,
                UserName = "Admin123",
                PasswordHash = adminPassword,
                Salt = adminSalt
            };

            context.Administrators.AddOrUpdate(x => x.Id, admin);

        }
    }
}
