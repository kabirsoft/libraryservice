using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService_datalayer.Models
{
    public class Author
    {      
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is not valid")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }        
       
        public DateTime Created { get; set; } = DateTime.Now;

        public virtual ICollection<Book> Book { get; set; }


        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}
