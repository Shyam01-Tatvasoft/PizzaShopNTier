using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Unit
{
    public int Id { get; set; }

    public string? Shortname { get; set; }

    public string Name { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual ICollection<Menuitem> Menuitems { get; set; } = new List<Menuitem>();

    public virtual ICollection<Modifier> Modifiers { get; set; } = new List<Modifier>();
}
