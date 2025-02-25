using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels;
public class ResetPasswordViewModel{
    [Required(ErrorMessage = "Token is Required.")]
    public string Token { get; set; } = null!;

    [Required(ErrorMessage = "New Password is required.")]
    public string NewPassword { get; set; } = null!;

    [Required(ErrorMessage = "Confirm New Password is required.")]
    [Compare("NewPassword", ErrorMessage = "Password doesn't match")]
    public string ConfirmNewPassword { get; set; } = null!;
}