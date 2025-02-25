using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels;

public class ChangePasswordViewModel
{
    [Required(ErrorMessage = "Current Password is required.")]
    public string CurrentPassword { get; set; }
    
    [Required, DataType(DataType.Password), MinLength(8)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&]).{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.")]
    public string NewPassword { get; set; }
    
    [Required(ErrorMessage ="Confirm Password Field is Required."), DataType(DataType.Password), Compare("NewPassword", ErrorMessage ="Password do not match")]
    public string ConfirmNewPassword { get; set; }
}
