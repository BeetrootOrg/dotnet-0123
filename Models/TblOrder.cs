using System;
using System.Collections.Generic;

namespace dotnet_0123.Models;

public partial class TblOrder
{
    public long Id { get; set; }

    public long CustomerId { get; set; }

    public long BookId { get; set; }

    public DateTime TakenDate { get; set; }

    public DateTime BackDate { get; set; }

    public virtual TblBook Book { get; set; } = null!;

    public virtual TblCustomer Customer { get; set; } = null!;
}
