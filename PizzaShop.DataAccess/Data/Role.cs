using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Rolepermission> Rolepermissions { get; set; } = new List<Rolepermission>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
