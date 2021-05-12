using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_ADONET.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int Year { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Price { get; set; }
        public bool IsPartBookSeries { get; set; }

        public virtual List<Stock> Stocks { get; set; }
    }
}
