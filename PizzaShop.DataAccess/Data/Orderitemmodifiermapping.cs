using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Orderitemmodifiermapping
{
    public int Id { get; set; }

    public int? Orderitemid { get; set; }

    public int? Modifierid { get; set; }

    public short? Quantityofmodifier { get; set; }

    public decimal? Rateofmodifier { get; set; }

    public decimal? Totalamount { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Modifier? Modifier { get; set; }

    public virtual Orderitem? Orderitem { get; set; }
}
