using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_ADONET.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double Percent { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
