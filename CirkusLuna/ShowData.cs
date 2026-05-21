namespace CirkusLuna.Models
{
    // Fælles dataliste der deles mellem alle sider
    public static class ShowData
    {
        public static List<Show> Shows = new List<Show>();

        public static void Initialiser()
        {
            if (Shows.Count == 0)
            {
                Show show1 = new Show(1, "Copenhagen", DateTime.Today.AddDays(10));
                Show show2 = new Show(2, "Aarhus", DateTime.Today.AddDays(20));
                Show show3 = new Show(3, "Odense", DateTime.Today.AddDays(30));

                Artist artist1 = new Artist(1, "Lars", "lars@cirkus.dk", "Jonglør");
                Artist artist2 = new Artist(2, "Sofia", "sofia@cirkus.dk", "Luftakrobat");
                Artist artist3 = new Artist(3, "Mikkel", "mikkel@cirkus.dk", "Klovn");

                show1.AddArtist(artist1);
                show1.AddArtist(artist2);
                show2.AddArtist(artist2);
                show2.AddArtist(artist3);
                show3.AddArtist(artist1);

                Shows.Add(show1);
                Shows.Add(show2);
                Shows.Add(show3);
            }
        }
    }
}