using System.Collections.Concurrent;

namespace RazorPages.Domain.Entities;

public class InMemoryCatalog : ICatalog
{
    private readonly IClock _clock;

    public InMemoryCatalog(IClock clock)
    {
        _clock = clock;
    }
    
    private readonly ConcurrentBag<Product> _products = new()
    {
        new(1, "Milk", 50m, 5, "https://www.hysterectomy.org/wp-content/uploads/shutterstock_568076731.jpg",
            "Молочные","Молоко 3.2%, 1000мл"),
        new(2, "Bread", 30m, 10, "https://media.baamboozle.com/uploads/images/306786/1659329828_417612_url.jpeg",
            "Выпечка","Белый хлеб, 350гр"),
        new(3, "Chocolate", 60m, 3,
            "https://mykaleidoscope.ru/uploads/posts/2021-09/1632766939_41-mykaleidoscope-ru-p-shokolad-na-belom-fone-krasivo-foto-42.jpg",
            "Сладости","Молочный шоколад, 80гр")
    };

    private bool _isDiscount = false;

    public IReadOnlyCollection<Product> GetProducts()
    {
        if (_clock.GetCurrent().DayOfWeek == DayOfWeek.Sunday && !_isDiscount)
        {
            foreach (var product in _products)
            {
                product.Price *= 0.7m;
            }

            _isDiscount = true;
        }
        
        return _products;
    }

    public Product GetProduct(long id)
    {
        return _products.First(it => it.Id == id);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void ClearCatalog()
    {
        _products.Clear();
    }
}