using System.ComponentModel.DataAnnotations;
namespace PizzaShop.ViewModels;

public class CreateUserViewModel
{
    [Required(ErrorMessage = "First Name is required.")]
    public string Firstname { get; set; } = null!;

    [Required(ErrorMessage = "Last Name is required")]
    public string? Lastname { get; set; }

    [Required(ErrorMessage = "User Name is required")]
    [StringLength(20, MinimumLength=5)]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Phone is required")]
    [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required, DataType(DataType.Password), MinLength(8)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&]).{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.")]
    public string Password { get; set; } = null!;

    public string? Profileimage { get; set; }

    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; } = null!;

    [Required(ErrorMessage = "State is required")]
    public string State { get; set; } = null!;

    [Required(ErrorMessage = "City is required")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Zipcode is required")]
    public string? Zipcode { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "Role is required")]
    public string Role { get; set; }

    public int? Createdby { get; set; }
}