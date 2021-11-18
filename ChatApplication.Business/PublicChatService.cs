using ChatApplication.Data;
using ChatApplication.Data.Service;
using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Business
{
    public class PublicChatService
    {
        private UnitOfWork unitOfWork;

        //TODO: Create PublicChatService
        public PublicChat GetAllPublicChatInfo(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                unitOfWork = new UnitOfWork(context);

                var publicChat = unitOfWork.PublicChatRepository.GetById(id);

                publicChat.Messages = unitOfWork.MessageRepository.GetAll
                    (
                    filter: x => x.PublicChatId == id,
                    orderBy: y => y.OrderBy(z => z.SendDate)
                    );

                foreach (var msg in publicChat.Messages)
                {
                    var userName = unitOfWork.ApplicationUserRepository.Get(filter: x => x.Id == msg.SenderId).UserName;
                    msg.Sender.UserName = userName;
                }

                //var countUPC = unitOfWork.UserPublicChatRepository.GetAll(filter: x => x.PublicChatId == id);
                //List<UserPublicChat> userPublicChats = new List<UserPublicChat>();

                //foreach (var UPC in countUPC)
                //{
                //    var user = unitOfWork.ApplicationUserRepository.Get(filter: x => x.Id == UPC.ApplicationUserId);

                //    userPublicChats.Add(new UserPublicChat
                //    {
                //        User = user,
                //        ApplicationUserId = UPC.ApplicationUserId,
                //        Id = UPC.Id
                //    });
                //}

                //publicChat.UserPublicChats = userPublicChats;

                return publicChat;
            };
        }
    }
}
