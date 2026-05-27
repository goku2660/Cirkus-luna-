using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Opret en builder til webapplikationen
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Tilføj Razor Pages til applikationen
builder.Services.AddRazorPages();

// Byg applikationen
WebApplication app = builder.Build();

// Gør statiske filer tilgængelige fx CSS og billeder
app.UseStaticFiles();

// Aktivér routing så applikationen kan finde de rigtige sider
app.UseRouting();

// Tilknyt Razor Pages til routing
app.MapRazorPages();

// Start applikationen
app.Run();