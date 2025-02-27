using PizzaShop.ViewModels;

namespace PizzaShop.Service.Interfaces;

public interface IProfileService
{
    public bool UpdateProfileByEmail(ProfileViewModel model, string email);
    public ProfileViewModel GetUserProfile(string? email);

    public string ChangePassword(ChangePasswordViewModel model, string email);
}
