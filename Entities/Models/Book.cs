using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string Author { get; set; } = null!;
        [Required]
        public string? Description { get; set; }
        [Required]
        public int TotalPages { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Categories { get; set; } = null!;
        public DateTime DatePublished { get; set; }
        public bool IsRented { get; set; }
    }
}
