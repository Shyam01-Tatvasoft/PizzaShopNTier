using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Account
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Roleid { get; set; }

    public bool? Isdeleted { get; set; }

    public bool? Isfirstlogin { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Role? Role { get; set; }
}
