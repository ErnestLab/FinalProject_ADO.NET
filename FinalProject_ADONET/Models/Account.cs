using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_ADONET.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("TypeAccount")]
        public int TypeAccountId { get; set; }
        public virtual TypeAccount TypeAccount { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Passw { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [Required]
        public long Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
