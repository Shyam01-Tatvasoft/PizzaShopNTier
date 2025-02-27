using System.Threading.Tasks;
using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;
using PizzaShop.ViewModels;

namespace PizzaShop.DataAccess.Implementation;

public class UserRepository : IUserRepository
{
    private readonly PizzashopContext _context;
    private readonly IRoleRepository _role;

    public UserRepository(PizzashopContext context, IRoleRepository role)
    {
        _context = context;
        _role = role;
    }

    public User GetUserByEmail(string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        return user;
    }

    public User UpdateUserProfileByEmail(ProfileViewModel model, string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        user.Firstname = model.FirstName;
        user.Lastname = model.LastName;
        user.Username = model.UserName;
        user.Phone = model.Phone;
        user.City = model.City;
        user.State = model.State;
        user.Country = model.Country;
        user.Address = model.Address;
        user.Zipcode = model.ZipCode;
        _context.SaveChangesAsync();

        return user;
    }

    public List<UsersViewModel> GetUsers(string searchString, int pageIndex = 1, int pageSize = 3)
    {
        var userQuery = _context.Users.Where(u => u.Isdeleted == false);

        if (!string.IsNullOrEmpty(searchString))
        {
            userQuery = userQuery.Where(n => n.Firstname.Contains(searchString) || n.Lastname.Contains(searchString) || n.Phone.Contains(searchString));
        }

        var userList = new List<UsersViewModel>();

        var usersList = userQuery
            .OrderBy(u => u.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        foreach (var user in usersList)
        {
            userList.Add(new UsersViewModel
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Profileimage = user.Profileimage,
                Email = user.Email,
                Phone = user.Phone,
                Country = user.Country,
                State = user.State,
                City = user.City,
                Zipcode = user.Zipcode,
                Address = user.Address,
                Role = _role.GetRoleById(user.Roleid),
                Isactive = user.Isactive == true ? "Active" : "InActive",
                Username = user.Username
            });
        }
        return userList;
    }

    public int getUsersCount(string searchString)
    {
        var userQuery = _context.Users.Where(u => u.Isdeleted == false);

        if (!string.IsNullOrEmpty(searchString))
        {
            userQuery = userQuery.Where(n => n.Firstname.Contains(searchString) || n.Lastname.Contains(searchString) || n.Phone.Contains(searchString));
        }
        return userQuery.ToList().Count();
    }

    public void CreateUser(CreateUserViewModel model, string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        var role = _role.GetRoleById(user.Roleid);
        var newUser = new User
        {
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Username = model.Username,
            Roleid = _context.Roles.FirstOrDefault(r => r.Id == int.Parse(model.Role)).Id,
            Email = model.Email,
            Country = model.Country,
            State = model.State,
            City = model.City,
            Zipcode = model.Zipcode,
            Address = model.Address,
            Phone = model.Phone,
            Profileimage = model.Profileimage,
            Createdby = role,
            Createddate = DateTime.Now
        };
        _context.Users.Add(newUser);
        _context.SaveChanges();
    }

    public UpdateUserViewModel GetUpdateUserDetail(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        var updateUser = new UpdateUserViewModel
        {
            Id = user.Id,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Username = user.Lastname,
            Email = user.Email,
            Address = user.Address,
            City = user.City,
            State = user.State,
            Country = user.Country,
            Zipcode = user.Zipcode,
            Phone = user.Phone,
            Profileimage = user.Profileimage,
            Role = user.Roleid.ToString(),
            Updatedby = user.Id.ToString(),
            Updateddate = DateTime.Now,
            Status = user.Isactive == true ? "1" : "0"
        };

        return updateUser;
    }

    public void UpdateUser(UpdateUserViewModel model, int? RoleId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == model.Id);
        var role = _role.GetRoleById(RoleId);
        if (user != null)
        {
            user.Firstname = model.Firstname;
            user.Lastname = model.Lastname;
            user.Username = model.Username;
            user.Address = model.Address;
            user.Phone = model.Phone;
            user.City = model.City;
            user.State = model.State;
            user.Country = model.Country;
            user.Zipcode = model.Zipcode;
            user.Isactive = model.Status == "1" ? true : false;
            user.Roleid = int.Parse(model.Role);
            user.Updateddate = DateTime.Now;
            user.Updatedby = role;
            user.Profileimage = model.Profileimage;
            _context.SaveChanges();
        }
    }
    public void DeleteUser(int id, int updatedbyId)   //here we take role or userId
    {
        var deletedBy = _context.Users.FirstOrDefault(u => u.Id == updatedbyId);
        var role = _role.GetRoleById(deletedBy.Roleid);
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        user.Isdeleted = true;
        user.Updatedby = role;
        user.Updateddate = DateTime.Now;
        _context.SaveChanges();
    }

}
