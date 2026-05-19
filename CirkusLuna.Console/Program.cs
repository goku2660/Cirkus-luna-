using CirkusLuna.Models;
using CirkusLuna.Repositories;

ShowRepository showRepo = new ShowRepository();
ReservationRepository reservationRepo = new ReservationRepository();

Show show1 = new Show(1, "Copenhagen", DateTime.Today.AddDays(10));
Show show2 = new Show(2, "Aarhus", DateTime.Today.AddDays(20));
Show show3 = new Show(3, "Odense", DateTime.Today.AddDays(30));

showRepo.Add(show1);
showRepo.Add(show2);
showRepo.Add(show3);

Customer customer1 = new Customer(1, "Peter", "peter@mail.dk");

Reservation res1 = new Reservation(1, customer1, show1, 2);
reservationRepo.Add(res1);

Console.WriteLine("--- All shows ---");
foreach (Show show in showRepo.GetAll())
{
    Console.WriteLine(show.CityName + " - " + show.Date.ToString("dd/MM/yyyy"));
}

Console.WriteLine("--- Search Aarhus ---");
foreach (Show show in showRepo.SearchByCity("Aarhus"))
{
    Console.WriteLine(show.CityName);
}

Console.WriteLine("--- All reservations ---");
foreach (Reservation res in reservationRepo.GetAll())
{
    Console.WriteLine(res.Customer.Name + " - " + res.Show.CityName + " - " + res.NumberOfTickets + " tickets");
}