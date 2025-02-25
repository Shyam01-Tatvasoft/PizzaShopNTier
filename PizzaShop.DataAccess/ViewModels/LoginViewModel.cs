using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels;
public class LoginViewModel
{

    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;

    public bool RememberMe { get; set; }
}
