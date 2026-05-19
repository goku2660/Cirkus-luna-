using System;
using System.Collections.Generic;
using System.Text;

namespace CirkusLuna.Models
{
    public class Show
    {
        public int ShowId { get; set; }
        public string CityName { get; set; }
        public DateTime Date { get; set; }
        public int MaxSeats { get; set; }

        public Show(int showId, string cityName, DateTime date)
        {
            ShowId = showId;
            CityName = cityName;
            Date = date;
            MaxSeats = 150;
        }
    }
}