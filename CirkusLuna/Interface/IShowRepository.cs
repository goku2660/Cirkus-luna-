using System;
using System.Collections.Generic;
using System.Text;
using CirkusLuna.Models;

namespace CirkusLuna.Interfaces
{
    // Interface definerer hvad ShowRepository skal kunne
    // Det er en kontrakt som ShowRepository skal opfylde
    public interface IShowRepository
    {
        // Tilføj et show til listen
        void Add(Show show);

        // Hent alle shows fra listen
        List<Show> GetAll();

        // Søg efter shows i en bestemt by
        List<Show> SearchByCity(string cityName);
    }
}