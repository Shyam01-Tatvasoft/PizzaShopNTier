using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Modifier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Rate { get; set; }

    public short Quantity { get; set; }

    public bool? Isdeleted { get; set; }

    public string Description { get; set; } = null!;

    public int? Modifiergroupid { get; set; }

    public int? Unitid { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Modifiergroup? Modifiergroup { get; set; }

    public virtual ICollection<Orderitemmodifiermapping> Orderitemmodifiermappings { get; set; } = new List<Orderitemmodifiermapping>();

    public virtual Unit? Unit { get; set; }
}
