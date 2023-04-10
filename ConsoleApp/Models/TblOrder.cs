using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblOrder
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual TblCustomer? Customer { get; set; }

    public virtual TblEmployee? Employee { get; set; }

    public virtual ICollection<TblOrdersProduct> TblOrdersProducts { get; } = new List<TblOrdersProduct>();
}
