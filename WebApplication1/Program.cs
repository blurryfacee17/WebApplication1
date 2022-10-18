var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/new_year", DaysUntilNewYear);

int DaysUntilNewYear()
{
    var now = DateTime.Today;
    var newYearTime = new DateTime(now.Year + 1, 1, 1);
    var result = newYearTime - now;
    return result.Days;
}

app.Run();