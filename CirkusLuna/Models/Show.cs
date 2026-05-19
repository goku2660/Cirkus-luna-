using System;
using System.Collections.Generic;
using System.Text;

namespace CirkusLuna.Models
{
    // Show repræsenterer en forestilling i en bestemt by på en bestemt dato
    public class Show
    {
        // ID for showet
        public int ShowId { get; set; }

        // Navnet på byen hvor showet foregår
        public string CityName { get; set; }

        // Datoen for showet
        public DateTime Date { get; set; }

        // Maksimalt antal pladser altid 150
        public int MaxSeats { get; set; }

        // Konstruktør opretter et nyt show med id, by og dato
        public Show(int showId, string cityName, DateTime date)
        {
            ShowId = showId;
            CityName = cityName;
            Date = date;
            MaxSeats = 150;
        }
    }
}