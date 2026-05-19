using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CirkusLuna.Web.Pages
{
    public class SeatModel : PageModel
    {
        public bool SaedeValgt { get; set; } = false;
        public bool Bekraeftet { get; set; } = false;
        public string SaedeNavn { get; set; } = "";
        public string BekraeftetTekst { get; set; } = "";
        public List<string> ValgteSeader { get; set; } = new List<string>();
        public List<string> BekraeftedeSeader { get; set; } = new List<string>();

        public void OnGet()
        {
            string gemteValgte = TempData.Peek("ValgteSeader") as string;
            if (gemteValgte != null && gemteValgte != "")
            {
                string[] array = gemteValgte.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    ValgteSeader.Add(array[i]);
                }
            }

            string gemteBekraeftede = TempData.Peek("BekraeftedeSeader") as string;
            if (gemteBekraeftede != null && gemteBekraeftede != "")
            {
                string[] array = gemteBekraeftede.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    BekraeftedeSeader.Add(array[i]);
                }
            }
        }

        public void OnPost()
        {
            // Hent gemte valgte sæder
            string gemteValgte = TempData.Peek("ValgteSeader") as string;
            if (gemteValgte != null && gemteValgte != "")
            {
                string[] array = gemteValgte.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    ValgteSeader.Add(array[i]);
                }
            }

            // Hent bekræftede sæder
            string gemteBekraeftede = TempData.Peek("BekraeftedeSeader") as string;
            if (gemteBekraeftede != null && gemteBekraeftede != "")
            {
                string[] array = gemteBekraeftede.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    BekraeftedeSeader.Add(array[i]);
                }
            }

            SaedeNavn = Request.Form["SaedeNavn"];

            // Tilføj eller fjern sæde fra valgte
            if (ValgteSeader.Contains(SaedeNavn))
            {
                ValgteSeader.Remove(SaedeNavn);
            }
            else
            {
                ValgteSeader.Add(SaedeNavn);
            }

            TempData["ValgteSeader"] = string.Join(",", ValgteSeader);
            TempData["BekraeftedeSeader"] = string.Join(",", BekraeftedeSeader);

            if (ValgteSeader.Count > 0)
            {
                SaedeValgt = true;
            }
        }

        public void OnPostBestil()
        {
            string navn = Request.Form["Navn"];
            string antal = Request.Form["Antal"];

            // Hent bekræftede sæder
            string gemteBekraeftede = TempData.Peek("BekraeftedeSeader") as string;
            if (gemteBekraeftede != null && gemteBekraeftede != "")
            {
                string[] array = gemteBekraeftede.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    BekraeftedeSeader.Add(array[i]);
                }
            }

            // Hent valgte sæder og flyt dem til bekræftede
            string gemteValgte = TempData.Peek("ValgteSeader") as string;
            if (gemteValgte != null && gemteValgte != "")
            {
                string[] array = gemteValgte.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    BekraeftedeSeader.Add(array[i]);
                }
            }

            TempData["BekraeftedeSeader"] = string.Join(",", BekraeftedeSeader);
            TempData["ValgteSeader"] = "";

            BekraeftetTekst = navn + " har reserveret " + antal + " billet(ter)!";
            Bekraeftet = true;
        }

        public string GetSaedeKlasse(string saede)
        {
            if (BekraeftedeSeader.Contains(saede))
            {
                return "reserveret";
            }
            if (ValgteSeader.Contains(saede))
            {
                return "valgt";
            }
            return "ledig";
        }
    }
}