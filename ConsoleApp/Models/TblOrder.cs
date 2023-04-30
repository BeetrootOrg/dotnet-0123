using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblOrder
{
    public int Id { get; set; }

    public DateTime TakeDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public int BookId { get; set; }

    public string CustomerEmail { get; set; } = null!;

    public virtual TblBook Book { get; set; } = null!;

    public virtual TblCustomer CustomerEmailNavigation { get; set; } = null!;
}
