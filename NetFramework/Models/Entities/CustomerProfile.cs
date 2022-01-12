using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class CustomerProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MailingAddress { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
