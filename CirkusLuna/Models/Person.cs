using System;
using System.Collections.Generic;
using System.Text;

namespace CirkusLuna.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}