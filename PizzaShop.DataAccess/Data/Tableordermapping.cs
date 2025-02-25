using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Tableordermapping
{
    public int Id { get; set; }

    public int? Orderid { get; set; }

    public int? Tableid { get; set; }

    public short Noofpersons { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Table? Table { get; set; }
}
