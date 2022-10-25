namespace RazorPages.Domain.Entities;

public class CategoryList : ICategoryList
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