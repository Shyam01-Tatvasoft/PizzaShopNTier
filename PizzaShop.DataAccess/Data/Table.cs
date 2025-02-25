using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Table
{
    public int Id { get; set; }

    public int? Sectionid { get; set; }

    public string Name { get; set; } = null!;

    public short Capacity { get; set; }

    public string Status { get; set; } = null!;

    public bool? Isavailable { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Section? Section { get; set; }

    public virtual ICollection<Tableordermapping> Tableordermappings { get; set; } = new List<Tableordermapping>();

    public virtual ICollection<Waitingtoken> Waitingtokens { get; set; } = new List<Waitingtoken>();
}
