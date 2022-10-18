using Microsoft.AspNetCore.Http.Json;
using OnlineStore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JsonOptions>(
    options =>
    {
        options.SerializerOptions.WriteIndented = true;
    });

var app = builder.Build();
var catalog = new Catalog();

app.MapGet("/", () => "Hello World!");
app.MapGet("/catalog",() =>
{
    return catalog.GetProducts();
});

app.MapGet("/headers", (HttpContext context) =>
{
    return context.Request.Headers;
});

app.MapPost("/api/product", (string name,decimal price,double stock) =>
{
    catalog.AddProduct(new Product(name, price, stock));
});

app.MapGet("/clear",catalog.ClearCatalog);

app.Run();