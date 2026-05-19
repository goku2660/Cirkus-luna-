using System;
using System.Collections.Generic;
using System.Text;

namespace CirkusLuna.Models
{
    // Artist repræsenterer en artist der optræder i shows
    // Artist arver fra Person og får derfor Name og Email automatisk
    public class Artist : Person
    {
        //  ID for artisten
        public int ArtistId { get; set; }

        // Artistens speciale fx Jonglør eller andet
        public string Specialty { get; set; }

        // Konstruktør  sender name og email videre til Person
        public Artist(int artistId, string name, string email, string specialty)
            : base(name, email)
        {
            ArtistId = artistId;
            Specialty = specialty;
        }
    }
}