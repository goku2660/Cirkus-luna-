using Microsoft.AspNetCore.Mvc;
using CirkusLuna.Models;
using CirkusLuna.Repositories;
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
            string gemteShows = TempData.Peek("Shows") as string;
            if (gemteShows != null && gemteShows != "")
            {
                string[] showArray = gemteShows.Split(';');
                for (int i = 0; i < showArray.Length; i++)
                {
                    string[] dele = showArray[i].Split(',');
                    Show show = new Show(int.Parse(dele[0]), dele[1], DateTime.Parse(dele[2]));
                    Shows.Add(show);
                }
            }
            else
            {
                Shows.Add(new Show(1, "Copenhagen", DateTime.Today.AddDays(10)));
                Shows.Add(new Show(2, "Aarhus", DateTime.Today.AddDays(20)));
                Shows.Add(new Show(3, "Odense", DateTime.Today.AddDays(30)));
                GemShows();
            }
        }

        public void OnPostTilfoejShow()
        {
            string cityName = Request.Form["CityName"];
            string dateString = Request.Form["Date"];
            DateTime date = DateTime.Parse(dateString);

            IndlaesShows();
            int nyId = Shows.Count + 1;
            Shows.Add(new Show(nyId, cityName, date));
            GemShows();

            BekraeftetTekst = cityName + " er tilføjet!";
            Bekraeftet = true;
        }

        public void OnPostAendreDato()
        {
            int showId = int.Parse(Request.Form["ShowId"]);
            string nyDatoString = Request.Form["NyDato"];
            DateTime nyDato = DateTime.Parse(nyDatoString);

            IndlaesShows();
            for (int i = 0; i < Shows.Count; i++)
            {
                if (Shows[i].ShowId == showId)
                {
                    Shows[i].Date = nyDato;
                    BekraeftetTekst = Shows[i].CityName + " er opdateret!";
                }
            }
            GemShows();
            Bekraeftet = true;
        }

        private void IndlaesShows()
        {
            string gemteShows = TempData.Peek("Shows") as string;
            if (gemteShows != null && gemteShows != "")
            {
                string[] showArray = gemteShows.Split(';');
                for (int i = 0; i < showArray.Length; i++)
                {
                    string[] dele = showArray[i].Split(',');
                    Show show = new Show(int.Parse(dele[0]), dele[1], DateTime.Parse(dele[2]));
                    Shows.Add(show);
                }
            }
        }

        private void GemShows()
        {
            string gemteShows = "";
            for (int i = 0; i < Shows.Count; i++)
            {
                gemteShows += Shows[i].ShowId + "," + Shows[i].CityName + "," + Shows[i].Date.ToString("yyyy-MM-dd");
                if (i < Shows.Count - 1)
                {
                    gemteShows += ";";
                }
            }
            TempData["Shows"] = gemteShows;
        }
    }
}