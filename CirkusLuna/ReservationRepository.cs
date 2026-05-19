using CirkusLuna.Models;

namespace CirkusLuna.Repositories
{
    // ReservationRepository gemmer og henter reservationer
    // Al dataadgang til reservationer foregår her
    public class ReservationRepository
    {
        // In-memory liste der gemmer alle reservationer
        public List<Reservation> Reservations = new List<Reservation>();

        // Tilføj en ny reservation til listen
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