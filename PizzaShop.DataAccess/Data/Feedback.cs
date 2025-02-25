using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Feedback
{
    public int Id { get; set; }

    public int? Orderid { get; set; }

    public decimal? Avgrating { get; set; }

    public string? Comment { get; set; }

    public short? Food { get; set; }

    public short? Service { get; set; }

    public short? Ambience { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Order? Order { get; set; }
}
