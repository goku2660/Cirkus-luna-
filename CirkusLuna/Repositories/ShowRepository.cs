using System;
using System.Collections.Generic;
using System.Text;
using CirkusLuna.Models;
using CirkusLuna.Interfaces;

namespace CirkusLuna.Repositories
{
    // ShowRepository implementerer IShowRepository
    // Al dataadgang til shows foregår her
    public class ShowRepository : IShowRepository
    {
        // liste der gemmer alle shows
        public List<Show> Shows = new List<Show>();

        // Tilføj et show til listen
        public void Add(Show show)
        {
            Shows.Add(show);
        }

        // Hent alle shows fra listen
        public List<Show> GetAll()
        {
            return Shows;
        }

        // Lineær søgning  finder shows i en bestemt by
        // Gennemgår alle shows ét ad gangen og sammenligner bynavnet
        public List<Show> SearchByCity(string cityName)
        {
            List<Show> result = new List<Show>();

            for (int i = 0; i < Shows.Count; i++)
            {
                // ToLower() gør søgningen ikke case sensitiv
                // fx "Copenhagen" og "copenhagen" giver samme resultat
                if (Shows[i].CityName.ToLower() == cityName.ToLower())
                {
                    result.Add(Shows[i]);
                }
            }

            return result;
        }
    }
}