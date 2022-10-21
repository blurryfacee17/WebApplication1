using System.ComponentModel.DataAnnotations;

namespace RazorPages.ViewModels;

public class CategoryAdditionModel
{
    [Required]
    public string Name { get; set; }
}