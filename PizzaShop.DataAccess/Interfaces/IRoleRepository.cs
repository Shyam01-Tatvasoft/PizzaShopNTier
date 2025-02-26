using PizzaShop.DataAccess.Data;

namespace PizzaShop.DataAccess.Interfaces;

public interface IRoleRepository
{
    public Role GetRoleById(int? id);

}
