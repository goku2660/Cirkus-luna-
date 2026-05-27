using CirkusLuna.Models;
using CirkusLuna.Interfaces;

namespace CirkusLuna.Repositories
{
    // ReservationRepository implementerer IReservationRepository
    // Al dataadgang til reservationer foregår her
    public class ReservationRepository : IReservationRepository
    {
        //  liste der gemmer alle reservationer
        public List<Reservation> Reservations = new List<Reservation>();

        // Tilføj en reservation til listen
        public void Add(Reservation reservation)
        {
            Reservations.Add(reservation);
        }

        // Hent alle reservationer fra listen
        public List<Reservation> GetAll()
        {
            return Reservations;
        }
    }
}