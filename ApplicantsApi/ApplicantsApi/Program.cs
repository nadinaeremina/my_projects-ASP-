using ApplicantsApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("/", () => new { Message = "Server is running"} );
app.MapGet("/ping", () => new { Message = "pong" });

// Applicants CRUD

// Get /applicant
app.MapGet("/applicant", async (ApplicationDbContext db) => await db.Applicants.ToListAsync());

// Get /applicant/{id}
app.MapGet("/applicant/{id:int}", async (int id, ApplicationDbContext db) =>
{
    Applicant? applicant = await db.Applicants.FirstOrDefaultAsync(a => a.Id == id);
    if (applicant == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(applicant);
});

// Post /applicant
app.MapPost("/applicant", async (ApplicantInfo info, ApplicationDbContext db) =>
{
    Applicant applicant = new Applicant()
    {
        Name = info.Name,
        BirtDate = info.BirthDate,
    };
    await db.AddAsync(applicant);
    await db.SaveChangesAsync();
    return Results.Created(); // 201
});

// Post /applicant/international
app.MapPost("/applicant/international", async (ApplicantInfo info, ApplicationDbContext db) =>
{
    Applicant applicant = new Applicant()
    {
        Name = info.Name,
        BirtDate = info.BirthDate,
        IsInternational = true
    };
    await db.AddAsync(applicant);
    await db.SaveChangesAsync();
    return Results.Created(); // 201
});

// Delete /applicant/{id}
app.MapDelete("/applicant/{id:int}", async (int id, ApplicationDbContext db) =>
{
    Applicant? applicant = await db.Applicants.FirstOrDefaultAsync(a => a.Id == id);
    if (applicant == null)
    {
        return Results.NotFound();
    }
    // �� ������ ������������� 'remove'
    // ������ ��� ������ ��������� �� � ������ ������ 'remove()'
    // � � ������ ������ 'SaveChangesAsync()'
    db.Applicants.Remove(applicant);
    await db.SaveChangesAsync();
    return Results.NoContent(); // 204
});

app.Run();

// ��� ���� ����� �����������
record ApplicantInfo(string Name, DateOnly BirthDate);