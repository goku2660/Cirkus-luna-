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
            ShowRepository repo = new ShowRepository();
            repo.Add(new Show(1, "Copenhagen", DateTime.Today.AddDays(10)));
            repo.Add(new Show(2, "Aarhus", DateTime.Today.AddDays(20)));
            repo.Add(new Show(3, "Odense", DateTime.Today.AddDays(30)));
            Shows = repo.GetAll();
        }

        public void OnPost()
        {
            SoegBy = Request.Form["SoegBy"];

            ShowRepository repo = new ShowRepository();
            repo.Add(new Show(1, "Copenhagen", DateTime.Today.AddDays(10)));
            repo.Add(new Show(2, "Aarhus", DateTime.Today.AddDays(20)));
            repo.Add(new Show(3, "Odense", DateTime.Today.AddDays(30)));

            if (SoegBy == "")
            {
                Shows = repo.GetAll();
            }
            else
            {
                Shows = repo.SearchByCity(SoegBy);
            }
        }
    }
}