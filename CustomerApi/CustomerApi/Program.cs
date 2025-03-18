using CustomerApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("/", () => new { Message = "Server is running" });
app.MapGet("/ping", () => new { Message = "pong" });

// Customers CRUD

// Get /customer
app.MapGet("/customer", async (ApplicationDbContext db) => await db.Customers.ToListAsync());

// Get /customer/{id}
app.MapGet("/customer/{id:int}", async (int id, ApplicationDbContext db) =>
{
    Customer? customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == id);
    if (customer == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(customer);
});

// Post /customer
app.MapPost("/customer", async (CustomerInfo info, ApplicationDbContext db) =>
{
    Customer customer = new Customer()
    {
        Name = info.Name,
        Email = info.Email,
        RegistrationDate = DateOnly.FromDateTime(DateTime.Now)
    };
    await db.AddAsync(customer);
    await db.SaveChangesAsync();
    return Results.Created(); // 201
});

// Delete /customer/{id}
app.MapDelete("/customer/{id:int}", async (int id, ApplicationDbContext db) =>
{
    Customer? customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == id);
    if (customer == null)
    {
        return Results.NotFound();
    }
    // не бывает ассинхронного 'remove'
    // потому что обьект удаляется не в момент вызова 'remove()'
    // а в момент вызова 'SaveChangesAsync()'
    db.Customers.Remove(customer);
    await db.SaveChangesAsync();
    return Results.NoContent(); // 204
});

// PATCH /customer/{id} 
app.MapPatch("/customer/{id:int}", async (CustomerEdit edit, int id, ApplicationDbContext db) =>
{
    // сначала ищем
    Customer? customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == id);
    if (customer == null)
    {
        return Results.NotFound();
    }
    customer.Name = edit.Name;
    await db.SaveChangesAsync();
    return Results.NoContent(); // 204
});

// Post /customer/international/ редактирование имени сущности
//app.MapPost("/applicant/international", async (ApplicantInfo info, ApplicationDbContext db) =>
//{
//    Applicant applicant = new Applicant()
//    {
//        Name = info.Name,
//        BirtDate = info.BirthDate,
//        IsInternational = true
//    };
//    await db.AddAsync(applicant);
//    await db.SaveChangesAsync();
//    return Results.Created(); // 201
//});

//получение сущности по email; 
//поиск всех сущности по имени (включение подстроки с игнорированием регистра).

app.Run();

// все типы внизу описываются
record CustomerInfo(string Name, string Email);
record CustomerEdit(string Name);
record CustomerEmail(string Email);