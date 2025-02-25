using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime Date { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Waitingtoken> Waitingtokens { get; set; } = new List<Waitingtoken>();
}
