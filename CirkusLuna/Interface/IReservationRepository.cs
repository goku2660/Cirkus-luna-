using System;
using System.Collections.Generic;
using System.Text;
using CirkusLuna.Models;

namespace CirkusLuna.Interfaces
{
    // Interface definerer hvad ReservationRepository skal kunne
    // Det er en kontrakt som ReservationRepository skal opfylde
    public interface IReservationRepository
    {
        // Tilføj en reservation til listen
        void Add(Reservation reservation);

        // Hent alle reservationer fra listen
        List<Reservation> GetAll();
    }
}