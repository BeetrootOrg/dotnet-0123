using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblOrder
{
    public long Id { get; set; }

    public long CustomerId { get; set; }

    public long BookId { get; set; }

    public DateTime TakenDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual TblBook Book { get; set; }

    public virtual TblCustomer Customer { get; set; }
}
