using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblCounting
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int CustomerId { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public virtual TblBook Book { get; set; } = null!;

    public virtual TblCustomer Customer { get; set; } = null!;
}
