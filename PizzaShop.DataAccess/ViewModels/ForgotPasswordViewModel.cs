using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels;
public class ForgotPasswordViewModel{
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = null!;
}