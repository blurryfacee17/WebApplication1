using System.Collections.Concurrent;

namespace OnlineStore;

public class Catalog
{
    private readonly ConcurrentBag<Product> _products = new()
    {
        new("Milk", 50m, 5),
        new("Bread", 30m, 10),
        new("Chocolate", 60m, 3)
    };

    public ConcurrentBag<Product> GetProducts()
    {
        return _products;
    }

    public void AddProduct(string name, decimal price, double stock)
    {
        var newProduct = new Product(name, price, stock);
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