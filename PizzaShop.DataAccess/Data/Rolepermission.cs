using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Rolepermission
{
    public int Id { get; set; }

    public int? Roleid { get; set; }

    public int? Permissionid { get; set; }

    public bool? Canview { get; set; }

    public bool? Canaddedit { get; set; }

    public bool? Candelete { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Permission? Permission { get; set; }

    public virtual Role? Role { get; set; }
}
