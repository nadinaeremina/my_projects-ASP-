var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.MapRazorPages();

// ���������� ��� ����, ����� ����� ���� ������������ 'wwwroot'
app.UseStaticFiles();

app.Run();
