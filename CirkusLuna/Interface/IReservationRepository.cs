using System;
using System.Collections.Generic;
using System.Text;

using CirkusLuna.Models;

namespace CirkusLuna.Interfaces
{
    // Interface definerer hvad ReservationRepository skal kunne
    public interface IReservationRepository
    {
        void Add(Reservation reservation);
        List<Reservation> GetAll();
    }
}