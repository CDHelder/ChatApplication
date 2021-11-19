using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Domain.Entities
{
    public enum GroupType
    {
        Public,
        Private,
        OneToOne
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GroupType GroupType { get; set; }
        public string Password { get; set; }
        public List<Message> Messages { get; set; }
    }
}
