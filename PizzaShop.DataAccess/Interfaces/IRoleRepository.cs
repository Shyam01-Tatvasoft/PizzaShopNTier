using PizzaShop.DataAccess.Data;

namespace PizzaShop.DataAccess.Interfaces;

public interface IRoleRepository
{
    public string GetRoleById(int? id);

}
