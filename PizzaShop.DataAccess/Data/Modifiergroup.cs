using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Modifiergroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual ICollection<Mappingmenuitemwithmodifier> Mappingmenuitemwithmodifiers { get; set; } = new List<Mappingmenuitemwithmodifier>();

    public virtual ICollection<Modifier> Modifiers { get; set; } = new List<Modifier>();
}
