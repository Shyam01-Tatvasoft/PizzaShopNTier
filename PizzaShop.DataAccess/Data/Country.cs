using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
