namespace RazorPages.Domain.Entities;

public class Category
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}