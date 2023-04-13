using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class TblBook
{
    public int Id { get; set; }

    public int Isbn { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public DateOnly? PublishYear { get; set; }

    public virtual TblAuthor Author { get; set; } = null!;

    public virtual ICollection<TblCounting> TblCountings { get; set; } = new List<TblCounting>();
}
