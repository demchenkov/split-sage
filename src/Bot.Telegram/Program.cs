using SplitSage.Bot.Telegram.Common.Infrastructure.Bot;
using SplitSage.Bot.Telegram.Common.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddTelegramBot(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => Results.Ok("Running..."));

app.Run();