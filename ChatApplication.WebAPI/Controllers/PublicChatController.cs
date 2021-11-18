using ChatApplication.Business;
using ChatApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatApplication.WebAPI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/PublicChat")]
    public class PublicChatController : ApiController
    {
        private HashingService hashingService = new HashingService();
        private PublicChatService publicChatService = new PublicChatService();
        public PublicChatController()
        {

        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public PublicChat GetAllInformation(int id)
        {
            var publicChat = publicChatService.GetAllPublicChatInfo(id);

            return publicChat;
        }
    }
}
