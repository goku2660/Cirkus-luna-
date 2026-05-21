using CirkusLuna.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CirkusLuna.Web.Pages
{
    public class AdminModel : PageModel
    {
        public List<Show> Shows { get; set; } = new List<Show>();
        public bool Bekraeftet { get; set; } = false;
        public string BekraeftetTekst { get; set; } = "";

        public void OnGet()
        {
            ShowData.Initialiser();
            Shows = ShowData.Shows;
        }

        public void OnPostTilfoejShow()
        {
            ShowData.Initialiser();
            string cityName = Request.Form["CityName"];
            string dateString = Request.Form["Date"];
            DateTime date = DateTime.Parse(dateString);

            int nyId = ShowData.Shows.Count + 1;
            ShowData.Shows.Add(new Show(nyId, cityName, date));

            BekraeftetTekst = cityName + " er tilføjet!";
            Bekraeftet = true;
            Shows = ShowData.Shows;
        }

        public void OnPostAendreDato()
        {
            ShowData.Initialiser();
            int showId = int.Parse(Request.Form["ShowId"]);
            string nyDatoString = Request.Form["NyDato"];
            DateTime nyDato = DateTime.Parse(nyDatoString);

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

        public void OnPostTilfoejArtist()
        {
            ShowData.Initialiser();
            int showId = int.Parse(Request.Form["ShowId"]);
            string navn = Request.Form["ArtistNavn"];
            string specialitet = Request.Form["Specialitet"];

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