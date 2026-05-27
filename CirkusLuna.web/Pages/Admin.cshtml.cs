using CirkusLuna.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CirkusLuna.Web.Pages
{
    public class AdminModel : PageModel
    {
        // Liste over alle shows der vises på admin siden
        public List<Show> Shows { get; set; } = new List<Show>();

        // Viser en bekræftelsesbesked når noget er gemt
        public bool Bekraeftet { get; set; } = false;

        // Teksten i bekræftelsesbesked
        public string BekraeftetTekst { get; set; } = "";

        // Kører når admin siden åbnes – henter alle shows
        public void OnGet()
        {
            ShowData.Initialiser();
            Shows = ShowData.Shows;
        }

        // Kører når medarbejder tilføjer et nyt show
        public void OnPostTilfoejShow()
        {
            ShowData.Initialiser();

            // Hent by og dato fra formularen
            string cityName = Request.Form["CityName"];
            string dateString = Request.Form["Date"];
            DateTime date = DateTime.Parse(dateString);

            // Giv showet et unikt ID baseret på antal shows
            int nyId = ShowData.Shows.Count + 1;
            ShowData.Shows.Add(new Show(nyId, cityName, date));

            BekraeftetTekst = cityName + " er tilføjet!";
            Bekraeftet = true;
            Shows = ShowData.Shows;
        }

        // Kører når medarbejder ændrer datoen på et show
        public void OnPostAendreDato()
        {
            ShowData.Initialiser();

            // Hent show ID og ny dato fra formularen
            int showId = int.Parse(Request.Form["ShowId"]);
            string nyDatoString = Request.Form["NyDato"];
            DateTime nyDato = DateTime.Parse(nyDatoString);

            // Find showet med det rigtige ID og opdater datoen
            for (int i = 0; i < ShowData.Shows.Count; i++)
            {
                if (ShowData.Shows[i].ShowId == showId)
                {
                    ShowData.Shows[i].Date = nyDato;
                    BekraeftetTekst = ShowData.Shows[i].CityName + " er opdateret!";
                }
            }

            Bekraeftet = true;
            Shows = ShowData.Shows;
        }

        // Kører når medarbejder tilføjer en artist til et show
        public void OnPostTilfoejArtist()
        {
            ShowData.Initialiser();

            // Hent show ID, navn og specialitet fra formularen
            int showId = int.Parse(Request.Form["ShowId"]);
            string navn = Request.Form["ArtistNavn"];
            string specialitet = Request.Form["Specialitet"];

            // Find showet og tilføj artisten
            for (int i = 0; i < ShowData.Shows.Count; i++)
            {
                if (ShowData.Shows[i].ShowId == showId)
                {
                    Artist artist = new Artist(i + 1, navn, "", specialitet);
                    ShowData.Shows[i].AddArtist(artist);
                    BekraeftetTekst = navn + " er tilføjet til " + ShowData.Shows[i].CityName;
                }
            }

            Bekraeftet = true;
            Shows = ShowData.Shows;
        }
    }
}