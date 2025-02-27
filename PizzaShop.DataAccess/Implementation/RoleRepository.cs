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

    public string GetRoleById(int? id)
    {
        Console.WriteLine("id");
        var role = _context.Roles.FirstOrDefault(r => r.Id == id);
        Console.WriteLine("Role" + role.Name);
        return role.Name;
    }

}
