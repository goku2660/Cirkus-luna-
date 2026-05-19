using System;
using System.Collections.Generic;
using System.Text;

namespace CirkusLuna.Models
{
    public class Customer : Person
    {
        public int CustomerId { get; set; }

        public Customer(int customerId, string name, string email)
            : base(name, email)
        {
            CustomerId = customerId;
        }
    }
}