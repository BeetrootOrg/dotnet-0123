using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Models
{
    public record Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string Desription { get; set; } = string.Empty;
        public int Published { get; set; } = DateTime.Now.Year;
        [Required]
        public int InitialCount { get; set; }
        public virtual int? AuthorId { get; set; }
        public virtual Author? Author { get; set; }
        [NotMapped]
        public int TakenQty { get { return Histiries.Count(x => x.BookId == Id && x.Returned == null); } }
        [NotMapped]
        public int FreeQy { get { return InitialCount - TakenQty; } }
        public List<Histiry> Histiries { get; set; } = new();
    }
}