using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblCustomer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<TblOrder> TblOrders { get; } = new List<TblOrder>();
}
