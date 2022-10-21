using System.ComponentModel.DataAnnotations;

namespace RazorPages.ViewModels;

public class ProductAdditionModel
{
    [Required]
    public string Name { get; set; }
    [Range(1,1_000_000)]
    public decimal Price { get; set; }
    [Range(0,int.MaxValue)]
    public int Stock { get; set; }
    [Required]
    public string ImageSource { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Description { get; set; }
    
}