using CirkusLuna.Models;

namespace CirkusLuna.Repositories
{
    public class ReservationRepository
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