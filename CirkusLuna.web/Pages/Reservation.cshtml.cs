using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CirkusLuna.Web.Pages
{
    public class ReservationModel : PageModel
    {
        // Viser bekræftelsesbesked når reservation er gennemført
        public bool Confirmed { get; set; } = false;

        // Kundens navn fra formularen
        public string Name { get; set; } = "";

        // Kører når reservationssiden åbnes
        public void OnGet()
        {
        }

        // Kører når kunden klikker på Reservér knappen
        public void OnPost()
        {
            // Hent kundens navn fra formularen
            Name = Request.Form["Name"];

            // Vis bekræftelsesbesked
            Confirmed = true;
        }
    }
}