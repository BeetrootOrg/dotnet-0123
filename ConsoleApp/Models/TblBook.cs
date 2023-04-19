using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblBook
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Isbn { get; set; }

    public long AuthorId { get; set; }

    public int Amount { get; set; }

    public int Year { get; set; }

    public virtual TblAuthor Author { get; set; }

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
