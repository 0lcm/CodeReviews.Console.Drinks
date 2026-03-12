using drinksInfo._0lcm.Configuration;
using drinksInfo._0lcm.Logging;
using drinksInfo._0lcm.Models;
using drinksInfo._0lcm.ServiceContracts;
using drinksInfo._0lcm.Services;
using drinksInfo._0lcm.UserInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

var builder = Host.CreateApplicationBuilder(args);
var settingsManager = new SettingsManager();
var appSettings = settingsManager.Load();

var dbPath = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "drinksInfo.0lcm",
    "app.db");

builder.Services.AddSingleton<ApiService>();
builder.Services.AddSingleton(appSettings);
builder.Services.AddSingleton(settingsManager);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddTransient<IReviewCategoriesService, ReviewCategoriesCategoriesService>();
builder.Services.AddTransient<ReviewCategoriesUi>();

builder.Services.AddTransient<IFilterCategoriesService, FilterCategoriesService>();
builder.Services.AddTransient<FilterCategoriesUi>();

builder.Services.AddTransient<ILookupSpecificsService, LookupSpecificsService>();
builder.Services.AddTransient<LookupSpecificsUi>();

builder.Services.AddTransient<ISettingsService, SettingsService>();
builder.Services.AddTransient<SettingsUi>();

builder.Services.AddTransient<IDrinkStateService, DrinkStateService>();
builder.Services.AddTransient<DrinkStateService>();
builder.Services.AddTransient<FavoritesAndLeaderboardUi>();

builder.Services.AddSingleton<ConsoleUi>();

builder.Services.AddHttpClient(ApiConstants.ApiName,
    client => { client.BaseAddress = new Uri(ApiConstants.ApiBaseUrl); });
builder.Services.AddHostedService<Worker>();

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Warning);
builder.Logging.AddConsole(options => { options.FormatterName = "customFormatter"; });
builder.Logging.AddConsoleFormatter<CustomFormatter, ConsoleFormatterOptions>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}

await app.RunAsync();

public class Worker : BackgroundService
{
    private readonly ConsoleUi _console;

    public Worker(ConsoleUi consoleUi)
    {
        _console = consoleUi;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _console.MainMenu();
    }
}