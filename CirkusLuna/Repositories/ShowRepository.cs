using System;
using System.Collections.Generic;
using System.Text;

using CirkusLuna.Models;

namespace CirkusLuna.Repositories
{
    // ShowRepository gemmer og henter shows
    // Al dataadgang til shows foregår her
    public class ShowRepository
    {
        // In-memory liste der gemmer alle shows
        public List<Show> Shows = new List<Show>();

        // Tilføj et nyt show til listen
        public void Add(Show show)
        {
            Shows.Add(show);
        }

        // Hent alle shows fra listen
        public List<Show> GetAll()
        {
            return Shows;
        }

        //  søgning finder shows i en bestemt by
        // Gennemgår alle shows ét ad gangen og sammenligner bynavnet
        public List<Show> SearchByCity(string cityName)
        {
            List<Show> result = new List<Show>();

            for (int i = 0; i < Shows.Count; i++)
            {
                // ToLower() gør at søgningen ikke er case-sensitiv
                if (Shows[i].CityName.ToLower() == cityName.ToLower())
                {
                    result.Add(Shows[i]);
                }
            }

            return result;
        }
    }
}