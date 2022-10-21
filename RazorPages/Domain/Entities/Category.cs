namespace RazorPages.Entities;

public class Category
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}