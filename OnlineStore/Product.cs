namespace OnlineStore;

public class Product
{
    public Product(string name, decimal price, double stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Stock { get; set; }
    
}