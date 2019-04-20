using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService_datalayer.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Display(Name = "Published")]
        [Required(ErrorMessage = "Publiction is required")]
        public int PublicationYear { get; set; }

        public bool IsAvailable { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public int? CostId { get; set; }

        public virtual Cost Cost { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        //[Timestamp]
        //public byte[] RowVersion { get; set; }
    }
}
