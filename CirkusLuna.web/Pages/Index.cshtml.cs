using CirkusLuna.Models;
using CirkusLuna.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CirkusLuna.Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Show> Shows { get; set; } = new List<Show>();
        public string SoegBy { get; set; } = "";

        public void OnGet()
        {
            ShowData.Initialiser();
            Shows = ShowData.Shows;
        }

        public void OnPost()
        {
            ShowData.Initialiser();
            SoegBy = Request.Form["SoegBy"];

            if (SoegBy == "")
            {
                Shows = ShowData.Shows;
            }
            else
            {
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