using System;
using System.Collections.Generic;
using System.Text;

namespace CirkusLuna.Models
{
    // Reservation repræsenterer en booking lavet af en kunde til et show
    public class Reservation
    {
        // for reservationen
        public int ReservationId { get; set; }

        // Kunden der har lavet reservationen
        public Customer Customer { get; set; }

        // Showet som reservationen gælder for
        public Show Show { get; set; }

        // Antal billetter der er reserveret
        public int NumberOfTickets { get; set; }

        // Konstruktør – opretter en ny reservation
        public Reservation(int reservationId, Customer customer, Show show, int numberOfTickets)
        {
            ReservationId = reservationId;
            Customer = customer;
            Show = show;
            NumberOfTickets = numberOfTickets;
        }
    }
}