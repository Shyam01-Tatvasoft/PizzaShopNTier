using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Waitingtoken
{
    public int Id { get; set; }

    public int? Customerid { get; set; }

    public bool? Isdeleted { get; set; }

    public bool? Isassigned { get; set; }

    public int? Tableid { get; set; }

    public int? Sectionid { get; set; }

    public short Noofpersons { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Section? Section { get; set; }

    public virtual Table? Table { get; set; }
}
