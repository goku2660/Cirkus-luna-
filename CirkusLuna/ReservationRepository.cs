using CirkusLuna.Models;
using CirkusLuna.Interfaces;

namespace CirkusLuna.Repositories
{
    // ReservationRepository implementerer IReservationRepository
    public class ReservationRepository : IReservationRepository
    {
        public List<Reservation> Reservations = new List<Reservation>();

        public void Add(Reservation reservation)
        {
            Reservations.Add(reservation);
        }

        public List<Reservation> GetAll()
        {
            return Reservations;
        }
    }
}