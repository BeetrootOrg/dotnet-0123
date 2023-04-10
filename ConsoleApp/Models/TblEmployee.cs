using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblEmployee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Salary { get; set; }

    public virtual ICollection<TblOrder> TblOrders { get; } = new List<TblOrder>();
}
