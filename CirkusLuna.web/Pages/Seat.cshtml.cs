using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CirkusLuna.Web.Pages
{
    public class SeatModel : PageModel
    {
        // Viser reservationsformularen når et sæde er valgt
        public bool SaedeValgt { get; set; } = false;

        // Viser bekræftelsesbesked når reservation er gennemført
        public bool Bekraeftet { get; set; } = false;

        // Navnet på det valgte sæde
        public string SaedeNavn { get; set; } = "";

        // Teksten i bekræftelsesbesked
        public string BekraeftetTekst { get; set; } = "";

        // Liste over sæder kunden har valgt men ikke bekræftet endnu (vises blå)
        public List<string> ValgteSeader { get; set; } = new List<string>();

        // Liste over sæder der er bekræftet reserveret (vises grå)
        public List<string> BekraeftedeSeader { get; set; } = new List<string>();

        // Kører når siden åbnes – henter gemte sæder fra TempData
        public void OnGet()
        {
            // Hent valgte sæder fra TempData
            string gemteValgte = TempData.Peek("ValgteSeader") as string;
            if (gemteValgte != null && gemteValgte != "")
            {
                string[] array = gemteValgte.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    ValgteSeader.Add(array[i]);
                }
            }

            // Hent bekræftede sæder fra TempData
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

        // Kører når kunden klikker på et sæde
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

            // Hent det valgte sæde fra formularen
            SaedeNavn = Request.Form["SaedeNavn"];

            // Tilføj eller fjern sæde fra valgte
            // Hvis sædet allerede er valgt – fjern det (fravælg)
            // Hvis sædet ikke er valgt – tilføj det (vælg)
            if (ValgteSeader.Contains(SaedeNavn))
            {
                ValgteSeader.Remove(SaedeNavn);
            }
            else
            {
                ValgteSeader.Add(SaedeNavn);
            }

            // Gem opdaterede lister i TempData så de huskes ved næste indlæsning
            TempData["ValgteSeader"] = string.Join(",", ValgteSeader);
            TempData["BekraeftedeSeader"] = string.Join(",", BekraeftedeSeader);

            // Vis reservationsformularen hvis der er valgte sæder
            if (ValgteSeader.Count > 0)
            {
                SaedeValgt = true;
            }
        }

        // Kører når kunden bekræfter sin reservation
        public void OnPostBestil()
        {
            // Hent navn og antal billetter fra formularen
            string navn = Request.Form["Navn"];
            string antal = Request.Form["Antal"];

            // Hent bekræftede sæder fra TempData
            string gemteBekraeftede = TempData.Peek("BekraeftedeSeader") as string;
            if (gemteBekraeftede != null && gemteBekraeftede != "")
            {
                string[] array = gemteBekraeftede.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    BekraeftedeSeader.Add(array[i]);
                }
            }

            // Flyt valgte sæder over til bekræftede sæder
            string gemteValgte = TempData.Peek("ValgteSeader") as string;
            if (gemteValgte != null && gemteValgte != "")
            {
                string[] array = gemteValgte.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    BekraeftedeSeader.Add(array[i]);
                }
            }

            // Gem bekræftede sæder og nulstil valgte sæder
            TempData["BekraeftedeSeader"] = string.Join(",", BekraeftedeSeader);
            TempData["ValgteSeader"] = "";

            // Vis bekræftelsesbesked
            BekraeftetTekst = navn + " har reserveret " + antal + " billet(ter)!";
            Bekraeftet = true;
        }

        // Returnerer CSS klassen for et sæde baseret på dets status
        // reserveret = grå, valgt = blå, ledig = grøn
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