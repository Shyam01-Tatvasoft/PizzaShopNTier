using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PizzaShop.ViewModels;

public class UpdateUserViewModel
{
    [Required(ErrorMessage ="User Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    public string Firstname { get; set; } = null!;

    [Required(ErrorMessage = "Last Name is required")]
    public string? Lastname { get; set; }

    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Phone is required")]
    public string Phone { get; set; } = null!;

    public string Email { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public string Status { get; set; } = null!;

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

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }
}
