using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FinalProject_ADONET.Models;

namespace FinalProject_ADONET.ViewModels
{
    class StockViewModel : INotifyPropertyChanged
    {
        private Stock _stock;
        public StockViewModel(Stock stock)
        {
            _stock = stock;
        }

        public int Id
        {
            get { return _stock.Id; }
            set
            {
                _stock.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public double Percent
        {
            get { return _stock.Percent; }
            set
            {
                _stock.Percent = value;
                OnPropertyChanged("Percent");
            }
        }

        public int BookId
        {
            get { return _stock.BookId; }
            set
            {
                _stock.BookId = value;
                OnPropertyChanged("BookId");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}