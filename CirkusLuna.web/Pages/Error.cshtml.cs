using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace CirkusLuna.web.Pages
{
    // Fejlside vises automatisk når der opstår en fejl i applikationen
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        // ID på den fejlede anmodning
        public string? RequestId { get; set; }

        // Viser kun RequestId hvis den ikke er tom
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Kører når fejlsiden åbnes henter ID på den fejlede anmodning
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}