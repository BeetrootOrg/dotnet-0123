using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblAuthor
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int BirthYear { get; set; }

    public int? DeathYear { get; set; }

    public virtual ICollection<TblBook> TblBooks { get; set; } = new List<TblBook>();
}
