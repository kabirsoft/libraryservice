using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService_datalayer.Models
{
    public class Cost
    {
        [Key]
        public int Id { get; set; }

        //[DisplayFormat(DataFormatString = "{0:c0}", ApplyFormatInEditMode = true)]
        public double Price { get; set; }

        public bool Discount { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
