using System.Collections.Concurrent;

namespace RazorPages.Models;

public class Catalog
{
    private readonly ConcurrentBag<Product> _products = new()
    {
        new("Milk", 50m, 5,"https://www.hysterectomy.org/wp-content/uploads/shutterstock_568076731.jpg"),
        new("Bread", 30m, 10,"https://media.baamboozle.com/uploads/images/306786/1659329828_417612_url.jpeg"),
        new("Chocolate", 60m, 3,"https://mykaleidoscope.ru/uploads/posts/2021-09/1632766939_41-mykaleidoscope-ru-p-shokolad-na-belom-fone-krasivo-foto-42.jpg")
    };

    public ConcurrentBag<Product> GetProducts()
    {
        return _products;
    }

    public void AddProduct(string name, decimal price, double stock, string imageSource)
    {
        var newProduct = new Product(name, price, stock, imageSource);
        AddProduct(newProduct);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void ClearCatalog()
    {
        _products.TryTake(out _);
    }
}