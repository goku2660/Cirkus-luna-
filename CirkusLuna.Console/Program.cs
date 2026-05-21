using CirkusLuna.Models;
using CirkusLuna.Repositories;

// Opret repositories
ShowRepository showRepo = new ShowRepository();

// Opret artister
Artist artist1 = new Artist(1, "Lars", "lars@cirkus.dk", "Jonglør");
Artist artist2 = new Artist(2, "Sofia", "sofia@cirkus.dk", "Luftakrobat");
Artist artist3 = new Artist(3, "Ali", "ali@cirkus.dk", "køre på et hjulet cykel");
// Opret shows
Show show1 = new Show(1, "Copenhagen", DateTime.Today.AddDays(10));
Show show2 = new Show(2, "Aarhus", DateTime.Today.AddDays(20));
Show show3 = new Show(3, "Odense", DateTime.Today.AddDays(30));

// Tilføj artister til shows
show1.AddArtist(artist1);
show2.AddArtist(artist2);
show3.AddArtist(artist3);

// Tilføj shows
showRepo.Add(show1);
showRepo.Add(show2);
showRepo.Add(show3);

// Vis alle shows med artister
Console.WriteLine("--- All shows ---");
foreach (Show show in showRepo.GetAll())
{
    Console.WriteLine(show.CityName + " - " + show.Date.ToString("dd/MM/yyyy"));
    foreach (Artist artist in show.Artists)
    {
        Console.WriteLine("  " + artist.Name + " - " + artist.Specialty);
    }
}