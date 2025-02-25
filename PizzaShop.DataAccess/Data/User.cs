using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Profileimage { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Lastname { get; set; }

    public string Username { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Zipcode { get; set; }

    public string Address { get; set; } = null!;

    public int? Roleid { get; set; }

    public bool? Isdeleted { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Role? Role { get; set; }
}
