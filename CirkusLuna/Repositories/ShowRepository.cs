using System;
using System.Collections.Generic;
using System.Text;
using CirkusLuna.Models;
using CirkusLuna.Interfaces;

namespace CirkusLuna.Repositories
{
    // ShowRepository implementerer IShowRepository
    public class ShowRepository : IShowRepository
    {
        public List<Show> Shows = new List<Show>();

        public void Add(Show show)
        {
            Shows.Add(show);
        }

        public List<Show> GetAll()
        {
            return Shows;
        }

        public List<Show> SearchByCity(string cityName)
        {
            List<Show> result = new List<Show>();

            for (int i = 0; i < Shows.Count; i++)
            {
                if (Shows[i].CityName.ToLower() == cityName.ToLower())
                {
                    result.Add(Shows[i]);
                }
            }

            return result;
        }
    }
}