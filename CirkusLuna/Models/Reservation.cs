using System;
using System.Collections.Generic;
using System.Text;

namespace CirkusLuna.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Customer Customer { get; set; }
        public Show Show { get; set; }
        public int NumberOfTickets { get; set; }

        public Reservation(int reservationId, Customer customer, Show show, int numberOfTickets)
        {
            ReservationId = reservationId;
            Customer = customer;
            Show = show;
            NumberOfTickets = numberOfTickets;
        }
    }
}