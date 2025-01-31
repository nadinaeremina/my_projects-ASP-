using ExamSquareEquation;
using ExamSquareEquation.Messages;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api", () => new StringMessage() { Message = "Server is running!" });
app.MapGet("/api/ping", () => new StringMessage() { Message = "pong" });
app.MapPost("/api/solve", object (Coefficient coef) =>
{
int root = 0;
double x1 = 0;
double x2 = 0;
double discriminant = coef.B * coef.B - 4 * coef.A * coef.C;
if (coef.A == 0)
{
    ErrorMessage error = new ErrorMessage() { Message = "Неправильно заполненные данные!" };
    return error;
}
if (discriminant > 0)
{
    root = 2;
    x1 = (-coef.B + Math.Sqrt(discriminant) / 2 * coef.A);
    x2 = (-coef.B - Math.Sqrt(discriminant) / 2 * coef.A);
}
else if (discriminant == 0)
{
    root = 1;
    x1 = -coef.B / 2 * coef.A;
    x2 = x1;
}

return new StringData() { RootCount = root, X1 = x1, X2 = x2, coefficients = new Coefficient() {A=coef.A, B=coef.B, C=coef.C } };
});

app.Run();
