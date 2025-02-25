using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Order
{
    public int Id { get; set; }

    public int? Customerid { get; set; }

    public decimal Subtotalamount { get; set; }

    public decimal Totalamount { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Discount { get; set; }

    public string? Notes { get; set; }

    public string Status { get; set; } = null!;

    public bool? Isgstselected { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public int? Paymentid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual ICollection<Ordertaxmapping> Ordertaxmappings { get; set; } = new List<Ordertaxmapping>();

    public virtual Payment? Payment { get; set; }

    public virtual ICollection<Tableordermapping> Tableordermappings { get; set; } = new List<Tableordermapping>();
}
