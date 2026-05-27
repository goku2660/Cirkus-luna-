using System;
using System.Collections.Generic;
using System.Text;

namespace CirkusLuna.Models
{
    // Person er basisklasse for Customer og Artist
    // Den indeholder de fælles egenskaber som alle personer har
    public class Person
    {
        // Personens navn
        public string Name { get; set; }

        // Personens email
        public string Email { get; set; }

        // Konstruktør – kører automatisk når man laver et nyt objekt
        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}