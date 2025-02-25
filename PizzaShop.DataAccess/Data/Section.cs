using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Section
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public string? Description { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();

    public virtual ICollection<Waitingtoken> Waitingtokens { get; set; } = new List<Waitingtoken>();
}
