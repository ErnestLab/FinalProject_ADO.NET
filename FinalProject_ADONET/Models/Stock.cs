using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_ADONET.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public double Percent { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
