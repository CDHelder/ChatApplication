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


        //TODO: Dataseeding
        protected override void Seed(ApplicationDbContext context)
        {
            string userId_1 = "9051c13b-6d91-4207-929b-9a35b8a44a1f";
            string userPassword_1 = CreatePasswordHash("HenkHenk123!");

            List<ApplicationUser> users = new List<ApplicationUser> { 
                new ApplicationUser { Id = userId_1, Email = "Henk123@gmail.com", EmailConfirmed = true, UserName = "Henk123", PasswordHash = userPassword_1 } 
            };

            List<Message> publicChatMessages = new List<Message> {
                new Message { Id = 1, Content = "Bericht 1", ReadByReciever = false, SendDate = DateTime.Today,}
            };

            context.PrivateChats.AddOrUpdate(new PrivateChat
            {
                Id = 1,
                
            });

            context.PublicChats.AddOrUpdate(new PublicChat
            {
                Id = 1,
                Name = "Publieke Chat 1",
                Description = "De publieke chat waarbij iedereen mag praten"
            });

            context.GroupChats.AddOrUpdate(new GroupChat
            {
                Id = 1,
                Name = "Groeps Chat 1",
                Description = "De groeps chat waarbij niet iedereen mag meekijken en meepraten"
            });
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
