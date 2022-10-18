using Microsoft.AspNetCore.Mvc;
using RazorPages.Models;

namespace RazorPages.Controllers;

public class CatalogController : Controller
{
    private static Catalog _catalog = new();
    public IActionResult ProductsList()
    {
        return View(_catalog);
    }
}