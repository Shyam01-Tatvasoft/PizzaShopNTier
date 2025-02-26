using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;

namespace PizzaShop.DataAccess.Implementation;

public class RoleRepository: IRoleRepository
{
    private readonly PizzashopContext _context;

    public RoleRepository(PizzashopContext context)
    {
        _context = context;
    }
    public Role GetRoleById(int? id)
    {
        var role = _context.Roles.FirstOrDefault(r => r.Id == id);
        return role;
    }
}
