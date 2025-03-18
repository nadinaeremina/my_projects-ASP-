using CustomerApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("/", () => new { Message = "Server is running" });
app.MapGet("/ping", () => new { Message = "pong" });

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

app.Run();

// все типы внизу описываются
record CustomerInfo(string Name, string Email);
record CustomerEdit(string Name);
record CustomerEmail(string Email);