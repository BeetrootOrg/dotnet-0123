using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblAuthor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public DateOnly? DateOfDeath { get; set; }

    public virtual ICollection<TblBook> TblBooks { get; set; } = new List<TblBook>();
}
