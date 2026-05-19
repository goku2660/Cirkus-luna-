using System;
using System.Collections.Generic;
using System.Text;

namespace CirkusLuna.Models
{
    // Customer repræsenterer en kunde der kan reservere billetter
    // Customer arver fra Person og får derfor Name og Email automatisk
    public class Customer : Person
    {
        // ID for kunden
        public int CustomerId { get; set; }

        // Konstruktør  sender name og email videre til Person
        public Customer(int customerId, string name, string email)
            : base(name, email)
        {
            CustomerId = customerId;
        }
    }
}