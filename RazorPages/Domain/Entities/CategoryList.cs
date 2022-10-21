namespace RazorPages.Entities;

public class CategoryList
{
    private List<Category> _categories = new()
    {
        new Category("Молочные"),
        new Category("Выпечка"),
        new Category("Сладости")
    };

    public List<Category> GetCategories()
    {
        return _categories;
    }

    public void AddCategory(Category category)
    {
        _categories.Add(category);
    }
}