using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels;

public class UsersViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Profile Image is required")]
    public string? Profileimage { get; set; }

    [Required(ErrorMessage = "FirstName is required.")]
    public string Firstname { get; set; } = null!;

    [Required(ErrorMessage = "LastName is required")]
    public string? Lastname { get; set; }

    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Phone is required")]
    public string Phone { get; set; } = null!;

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

    public bool? Isdeleted { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public string Isactive { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }
}
