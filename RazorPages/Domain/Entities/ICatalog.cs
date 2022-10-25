using System.Collections.Concurrent;

namespace RazorPages.Domain.Entities;

public interface ICatalog
{
    IReadOnlyCollection<Product> GetProducts();
    Product GetProduct(long id);
    void AddProduct(Product product);
    void ClearCatalog();    
}