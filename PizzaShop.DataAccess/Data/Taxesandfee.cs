using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Taxesandfee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Percentge { get; set; }

    public decimal? Flatamount { get; set; }

    public bool? Isactive { get; set; }

    public bool? Isdefault { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual ICollection<Ordertaxmapping> Ordertaxmappings { get; set; } = new List<Ordertaxmapping>();
}
