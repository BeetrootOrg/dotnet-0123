using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<TblOrdersProduct> TblOrdersProducts { get; } = new List<TblOrdersProduct>();
}
