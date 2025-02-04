using Microsoft.EntityFrameworkCore;
using SplitSage.Bot.Telegram.Common.Application;
using SplitSage.Bot.Telegram.Common.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SplitSageDb");
builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

var app = builder.Build();

app.MapGet("/", () => Results.Ok("Running..."));

app.Run();
