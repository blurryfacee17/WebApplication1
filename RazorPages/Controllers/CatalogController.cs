using Microsoft.AspNetCore.Mvc;
using RazorPages.Domain.Entities;
using RazorPages.ViewModels;

namespace RazorPages.Controllers;

public class CatalogController : Controller
{
    private static Catalog _catalog = new();
    private static CategoryList _categoryList = new();
    public IActionResult ProductsList()
    {
        return View(_catalog);
    }

    [Route("{id}")]
    public IActionResult ProductInformation(long id)
    {
        return View(_catalog.GetProduct(id));
    }
    
    [HttpGet]
    public IActionResult ProductAddition()
    {
        return View(_categoryList);
    }

    [HttpPost]
    public IActionResult ProductAddition([FromForm] ProductAdditionModel model)
    {
        if (!ModelState.IsValid)
            return ValidationProblem();
        var maxId = _catalog.GetProducts().Max(it =>it.Id);
        var newId = maxId + 1;
        var product = new Product(newId, model.Name, model.Price, model.Stock, model.ImageSource,model.Category);
        _catalog.AddProduct(product);
        return View(_categoryList);
    }
    
    [HttpGet]
    public IActionResult CategoryAddition()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CategoryAddition([FromForm] CategoryAdditionModel model)
    {
        if (!ModelState.IsValid)
            return ValidationProblem();
        var category = new Category(model.Name);
        _categoryList.AddCategory(category);
        Console.WriteLine(model.Name);
        return View();
    }
}