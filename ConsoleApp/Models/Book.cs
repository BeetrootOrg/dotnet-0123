using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("tbl_books")]
    public record Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("author_id")]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }

        [Required]
        [Column("genre_id")]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("isbn")]
        public string Isbn { get; set; }

        [Required]
        [Column("year")]
        public int Year { get; set; }

        public virtual ICollection<History> History { get; set; }
    }
}