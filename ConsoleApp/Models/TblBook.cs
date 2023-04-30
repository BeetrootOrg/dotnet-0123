using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblBook
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public int AuthorId { get; set; }

    public virtual TblAuthor Author { get; set; } = null!;

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
