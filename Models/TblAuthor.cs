using System;
using System.Collections.Generic;

namespace dotnet_0123.Models;

public partial class TblAuthor
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<TblBook> TblBooks { get; set; } = new List<TblBook>();
}
