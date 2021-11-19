using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApplication.WebAPI.Models
{
    public class GroupViewModel
    {
        public Group Group { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}