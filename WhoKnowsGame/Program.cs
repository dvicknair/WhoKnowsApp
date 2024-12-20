using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Text.Json.Serialization;
using WhoKnowsGame.Components;
using WhoKnowsGame.Data;
using WhoKnowsGame.Services;
using WhoKnowsGame.Shared.Dtos;
using WhoKnowsGame.Shared.Interfaces;
using WhoKnowsGame.Shared.Models;
using WhoKnowsGame.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<WhoKnowsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WhoKnowsDbContext"),
    sqlServerOptions => sqlServerOptions.CommandTimeout(120)));

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddFluentUIComponents();

builder.Services.AddSignalR();

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        ["application/octet-stream"]);
});

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<WhoKnowsDbContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    var game = context.Riddles.FirstOrDefault();
    if (game == null)
    {
        context.Set<Game>().Add(new Game
        {
            Name = "Who Knows Bob",
            Riddles = [
                new() {
                        Question = "What is Katie's birthday?",
                        Answers = [
                            new() { Text = "December 6" },
                            new() { Text = "November 31" },
                            new() { Text = "December 8" },
                            new() { Text = "November 30" },
                        ],
                        AnswerId = 3
                    },
                    new() {
                        Question = "What city was Katie born in?",
                        Answers = [
                            new() { Text = "Independence" },
                            new() { Text = "Bogalusa" },
                            new() { Text = "Hammond" },
                            new() { Text = "Covington" },
                        ],
                        AnswerId = 6
                    }
            ]
        });
        context.SaveChanges();
    }
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapGet("/game/{gameId}", async ([FromServices] IGameService gameService, int gameId) => await gameService.GetGame(gameId));
app.MapGet("/playersss/{gameId}", async ([FromServices] IGameService gameService, int gameId) => await gameService.GetPlayers(gameId));
app.MapGet("/StartGame/{gameId}", async ([FromServices] IGameService gameService, int gameId) => await gameService.StartGame(gameId));
app.MapPost("/EnterGame", async ([FromServices] IGameService gameService, EnterGameDto enterGameDto) => await gameService.EnterGame(enterGameDto));
app.MapPost("/AnswerRiddle", async ([FromServices] IGameService gameService, AnswerRiddleDto answerRiddleDto) => await gameService.AnswerRiddle(answerRiddleDto));
app.MapGet("/GetGameResults/{gameId}", async ([FromServices] IGameService gameService, int gameId) => await gameService.GetGameResults(gameId));

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WhoKnowsGame.Client._Imports).Assembly);

app.MapHub<GameHub>("/gamehub");

app.Run();
