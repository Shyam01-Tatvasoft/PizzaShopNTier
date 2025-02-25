using System;
using System.Collections.Generic;

namespace PizzaShop.DataAccess.Data;

public partial class Orderitem
{
    public int Id { get; set; }

    public int? Menuitemid { get; set; }

    public int? Orderid { get; set; }

    public string Status { get; set; } = null!;

    public string? Comment { get; set; }

    public string Name { get; set; } = null!;

    public short Quantity { get; set; }

    public decimal Rate { get; set; }

    public decimal Amount { get; set; }

    public decimal Totalmodifieramount { get; set; }

    public decimal? Tax { get; set; }

    public decimal Totalamount { get; set; }

    public string? Instruction { get; set; }

    public short? Readyitemquantity { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public virtual Menuitem? Menuitem { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<Orderitemmodifiermapping> Orderitemmodifiermappings { get; set; } = new List<Orderitemmodifiermapping>();
}
