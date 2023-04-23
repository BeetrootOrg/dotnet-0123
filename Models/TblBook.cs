using System;
using System.Collections.Generic;

namespace dotnet_0123.Models;

public partial class TblBook
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public long AuthorId { get; set; }

    public string Genre { get; set; } = null!;

    public DateTime Year { get; set; }

    public virtual TblAuthor Author { get; set; } = null!;

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
