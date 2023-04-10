using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblOrdersProduct
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public virtual TblOrder Order { get; set; } = null!;

    public virtual TblProduct Product { get; set; } = null!;
}
