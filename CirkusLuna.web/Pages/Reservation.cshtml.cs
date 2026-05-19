using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CirkusLuna.Web.Pages
{
    public class ReservationModel : PageModel
    {
        public bool Confirmed { get; set; } = false;
        public string Name { get; set; } = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Name = Request.Form["Name"];
            Confirmed = true;
        }
    }
}
