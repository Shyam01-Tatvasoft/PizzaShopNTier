using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Invoice
{
    public int Id { get; set; }

    public int? Orderid { get; set; }

    public int? Modifierid { get; set; }

    public short Quantityofmodifier { get; set; }

    public decimal Rateofmodifier { get; set; }

    public decimal Totalamount { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Modifier? Modifier { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
