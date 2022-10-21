namespace RazorPages.Domain.Entities;

public class Product
{
    public Product(long id, string name, decimal price, int stock, string imageSource,string category)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
        ImageSource = imageSource;
        Category = category;
    }

    public Product(long id, string name, decimal price, int stock, string imageSource, string category, string description) 
        : this(id, name, price, stock, imageSource,category)
    {
        Description = description;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImageSource { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    
}