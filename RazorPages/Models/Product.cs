namespace RazorPages.Models;

public class Product
{
    public Product(string name, decimal price, double stock, string imageSource)
    {
        Name = name;
        Price = price;
        Stock = stock;
        ImageSource = imageSource;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Stock { get; set; }
    public string ImageSource { get; set; }
    
}