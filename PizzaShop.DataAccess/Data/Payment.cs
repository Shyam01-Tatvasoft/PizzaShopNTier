using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Payment
{
    public int Id { get; set; }

    public string Method { get; set; } = null!;

    public decimal Amount { get; set; }

    public string Status { get; set; } = null!;

    public int? Invoiceid { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Invoice? Invoice { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
