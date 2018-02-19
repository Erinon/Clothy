using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }

        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Order()
        {

        }

        public Order(string userId, string mail, string phone, string address)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            DateCreated = DateTime.UtcNow;

            Mail = mail;
            Phone = phone;
            Address = address;
        }
    }
}
