using DrinkingsCRUD.Model;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

// конфигурация отображения для float/double/decimal
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US")
    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

// конфигурация отображения для float/double/decimal
app.UseRequestLocalization();

app.MapGet("/drinks", async (ApplicationDbContext db) =>
{
    return await db.Drinks.ToListAsync();
});

app.MapGet("/drinks/{id:int}", async (int id, ApplicationDbContext db) =>
{
    return await db.Drinks.FirstOrDefaultAsync(ram => ram.Id == id);
});

app.MapPost("/drinks", async (Drink drink, ApplicationDbContext db) =>
{
    drink.Id = 0;
    await db.Drinks.AddAsync(drink);
    await db.SaveChangesAsync();
    return drink;
});

app.MapDelete("/drinks/{id:int}", async (int id, ApplicationDbContext db) =>
{
    // находим элемент - сохраняем найденный
    Drink? deleted = await db.Drinks.FirstOrDefaultAsync(ram => ram.Id == id);
    if (deleted != null)
    {
        db.Drinks.Remove(deleted);
        await db.SaveChangesAsync();
    }
    return deleted;
});

// PATCH /elements - элемента
app.MapPatch("/drinks", async (Drink drink, ApplicationDbContext db) =>
{
    // сначала ищем
    Drink? updated = await db.Drinks.FirstOrDefaultAsync(r => r.Id == drink.Id);
    // если есть - обновляем поля, айди не меняется
    if (updated != null)
    {
        updated.Title = drink.Title;
        updated.Volume = drink.Volume;
        updated.Price = drink.Price;
        updated.IsHot = drink.IsHot;
        await db.SaveChangesAsync();
    }
    return updated;
});

app.Run();