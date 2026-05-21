using System;
using System.Collections.Generic;
using System.Text;

using CirkusLuna.Models;

namespace CirkusLuna.Interfaces
{
    // Interface definerer hvad ShowRepository skal kunne
    public interface IShowRepository
    {
        void Add(Show show);
        List<Show> GetAll();
        List<Show> SearchByCity(string cityName);
    }
}