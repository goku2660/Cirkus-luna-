using CirkusLuna.Models;
using CirkusLuna.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CirkusLuna.Web.Pages
{
    public class IndexModel : PageModel
    {
        // Liste over shows der vises på forsiden
        public List<Show> Shows { get; set; } = new List<Show>();

        // Gemmer søgeteksten så den stadig vises i søgefeltet
        public string SoegBy { get; set; } = "";

        // Kører når siden åbnes – henter alle shows
        public void OnGet()
        {
            ShowData.Initialiser();
            Shows = ShowData.Shows;
        }

        // Kører når brugeren søger efter en by
        public void OnPost()
        {
            ShowData.Initialiser();
            SoegBy = Request.Form["SoegBy"];

            if (SoegBy == "")
            {
                // Hvis søgefeltet er tomt  vis alle shows
                Shows = ShowData.Shows;
            }
            else
            {
                // Brug lineær søgning til at finde shows i den søgte by
                ShowRepository repo = new ShowRepository();
                for (int i = 0; i < ShowData.Shows.Count; i++)
                {
                    repo.Add(ShowData.Shows[i]);
                }
                Shows = repo.SearchByCity(SoegBy);
            }
        }
    }
}