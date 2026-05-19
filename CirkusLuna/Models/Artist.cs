using System;
using System.Collections.Generic;
using System.Text;

namespace CirkusLuna.Models
{
    public class Artist : Person
    {
        public int ArtistId { get; set; }
        public string Specialty { get; set; }

        public Artist(int artistId, string name, string email, string specialty)
            : base(name, email)
        {
            ArtistId = artistId;
            Specialty = specialty;
        }
    }
}
