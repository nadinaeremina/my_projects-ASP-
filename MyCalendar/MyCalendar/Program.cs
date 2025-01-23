var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.MapRazorPages();

// подключаем для того, чтобы можно было использовать 'wwwroot'
app.UseStaticFiles();

app.Run();
