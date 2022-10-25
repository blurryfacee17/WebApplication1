namespace RazorPages.Domain.Entities;

public interface ICategoryList
{
    List<Category> GetCategories();
    void AddCategory(Category category);
}