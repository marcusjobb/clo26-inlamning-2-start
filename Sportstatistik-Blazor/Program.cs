// Startpunkt för Sportstatistik (Blazor). Här registreras alla delar, och sedan startar webbservern.
using System.Globalization;
using Sportstatistik.Components;
using Sportstatistik.Services;
using Sportstatistik.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using Sportstatistik.Models;

// Svenskt format på tal och datum.
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("sv-SE");

var builder = WebApplication.CreateBuilder(args);

// Connectionstring läses från user-secrets (nyckeln DB_CONNECTION), aldrig från koden.
// I Development läser WebApplication user-secrets automatiskt.
builder.Configuration.AddIniFile("atlas-credentials.env", optional: true);

builder.Services.AddSingleton<SportDatabase>(services =>
{
    var configuration = services.GetRequiredService<IConfiguration>();
    var connectionString = configuration["MONGODB_URI"]
        ?? throw new InvalidOperationException("MONGODB_URI saknas i konfigurationen.");
    return new SportDatabase(connectionString);
});

// Byt den här raden när ni har en riktig databas, till exempel:
//   builder.Services.AddSingleton<ILeagueRepository>(new MongoLeagueRepository(connectionString));
// Er databasklass ska skapa databasen och seeda exempeldata vid första start, om den är tom.
// Här passar till exempel mönstret Factory: en klass som väljer och skapar rätt repository
// utifrån konfigurationen, så att Program.cs inte behöver känna till varje databasklass.
// Låtsasdatabasen är Singleton så att listorna lever kvar mellan sidvisningarna.
builder.Services.AddSingleton<ILeagueRepository, InMemoryLeagueRepository>();

// De här ska ni bygga. Tills dess visar sidorna demodata eller "Inte implementerat ännu".
builder.Services.AddSingleton<IStandingsService, StandingsService>();
builder.Services.AddSingleton<IPositionService, PositionService>();
builder.Services.AddSingleton<ISquadLimitService, SquadLimitService>();
builder.Services.AddSingleton<IResultFormatter, ResultFormatter>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();

if (Environment.GetEnvironmentVariable("TEST_ATLAS") == "1")
{
    var db = app.Services.GetRequiredService<SportDatabase>();
    var testId = ObjectId.Parse("000000000000000000000999");

    var filter = Builders<Team>.Filter.Eq(team => team.Id, testId);
    var testTeam = new Team { Id = testId, Name = "Atlas testlag" };

    await db.Teams.ReplaceOneAsync(
        filter,
        testTeam,
        new ReplaceOptions { IsUpsert = true });

    var savedTeam = await db.Teams.Find(filter).SingleAsync();
    Console.WriteLine($"Atlas-test OK. Läste tillbaka {savedTeam.Name} (ID {savedTeam.Id}).");
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


