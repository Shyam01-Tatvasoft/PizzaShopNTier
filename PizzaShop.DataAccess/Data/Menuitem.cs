using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Menuitem
{
    public int Id { get; set; }

    public int? Categoryid { get; set; }

    public string Name { get; set; } = null!;

    public string Itemtype { get; set; } = null!;

    public decimal Rate { get; set; }

    public short Quantity { get; set; }

    public bool? Isavailable { get; set; }

    public bool? Isdeleted { get; set; }

    public string? Comment { get; set; }

    public int? Unitid { get; set; }

    public bool? Isdefaulttax { get; set; }

    public bool? Isfavourite { get; set; }

    public decimal? Taxpercentage { get; set; }

    public string? Shortcode { get; set; }

    public string? Description { get; set; }

    public string? Itemimage { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Mappingmenuitemwithmodifier> Mappingmenuitemwithmodifiers { get; set; } = new List<Mappingmenuitemwithmodifier>();

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual Unit? Unit { get; set; }
}
