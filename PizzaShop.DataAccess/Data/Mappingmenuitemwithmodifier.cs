using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Mappingmenuitemwithmodifier
{
    public int Id { get; set; }

    public int? Menuitemid { get; set; }

    public int? Modifiergroupid { get; set; }

    public short? Minselectionrequired { get; set; }

    public short? Maxselectionrequired { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Menuitem? Menuitem { get; set; }

    public virtual Modifiergroup? Modifiergroup { get; set; }
}
