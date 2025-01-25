using HomeworkCRUD.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

app.MapRazorPages();

app.Run();