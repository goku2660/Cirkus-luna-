namespace CirkusLuna.Models
{
    // Fælles dataliste der deles mellem alle sider
    // Static betyder at alle sider deler den samme liste
    public static class ShowData
    {
        // Listen over alle shows i systemet
        public static List<Show> Shows = new List<Show>();

        // Opretter standard shows og artister første gang siden indlæses
        // if (Shows.Count == 0) sikrer at data ikke tilføjes to gange
        public static void Initialiser()
        {
            if (Shows.Count == 0)
            {
                // Opret tre shows med by og dato
                Show show1 = new Show(1, "Copenhagen", DateTime.Today.AddDays(10));
                Show show2 = new Show(2, "Aarhus", DateTime.Today.AddDays(20));
                Show show3 = new Show(3, "Odense", DateTime.Today.AddDays(30));

                // Opret tre artister med navn, email og specialitet
                Artist artist1 = new Artist(1, "Lars", "lars@cirkus.dk", "Jonglør");
                Artist artist2 = new Artist(2, "Sofia", "sofia@cirkus.dk", "Luftakrobat");
                Artist artist3 = new Artist(3, "Mikkel", "mikkel@cirkus.dk", "Klovn");

                // Tilknyt artister til shows
                show1.AddArtist(artist1);
                show1.AddArtist(artist2);
                show2.AddArtist(artist2);
                show2.AddArtist(artist3);
                show3.AddArtist(artist1);

                // Tilføj shows til den fælles liste
                Shows.Add(show1);
                Shows.Add(show2);
                Shows.Add(show3);
            }
        }
    }
}