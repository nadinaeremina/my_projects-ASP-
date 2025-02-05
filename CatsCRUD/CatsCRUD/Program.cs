using CatsCRUD.Messages;
using CatsCRUD.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("api/show", async (ApplicationDbContext db) =>
{
    return await db.Cats.ToListAsync();
});

app.MapGet("api/show/{id:int}", async (int id, ApplicationDbContext db) =>
{
    return await db.Cats.FirstOrDefaultAsync(cat => cat.Id == id);
});

//{
//    "iid": 3,
//    "name": "Michael",
//    "img_link": "https://i.pinimg.com/originals/3d/19/e2/3d19e22f8fc92cdbd53337558220e262.jpg",
//    "age": 1,
//    "rate": 10,
//    "description": "Funny",
//    "favourite": true
//}

app.MapPost("api/add", async (Cat cat, ApplicationDbContext db) =>
{
    cat.Id = 0;
    await db.Cats.AddAsync(cat);
    await db.SaveChangesAsync();
    return cat;
});

app.MapPut("api/update", async (Cat cat, ApplicationDbContext db) =>
{
    // сначала ищем
    Cat? updated = await db.Cats.FirstOrDefaultAsync(c => c.Id == cat.Id);
    // если есть - обновляем поля, айди не меняется
    if (updated != null)
    {
        updated.Age = cat.Age;
        updated.Rate = cat.Rate;
        updated.Name = cat.Name;
        updated.Iid = cat.Iid;
        updated.Image_link = cat.Image_link;
        updated.Description = cat.Description;
        updated.Favourite = cat.Favourite;
        await db.SaveChangesAsync();
    }
    return updated;
});

app.MapDelete("/api/delete/{id:int}", async (int id, ApplicationDbContext db) =>
{
    // находим элемент - сохраняем найденный
    Cat? deleted = await db.Cats.FirstOrDefaultAsync(cat => cat.Id == id);
    if (deleted != null)
    {
        db.Cats.Remove(deleted);
        await db.SaveChangesAsync();
    }
    return deleted;
});

app.Run();
