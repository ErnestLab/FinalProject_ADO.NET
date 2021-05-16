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
    class BooksViewModel : INotifyPropertyChanged
    {
        private Book _book { get; set; }
        public BooksViewModel(Book book)
        {
            _book = book;
        }

        public int Id
        {
            get { return _book.Id; }
            set
            {
                _book.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string BookName
        {
            get { return _book.BookName; }
            set
            {
                _book.BookName = value;
                OnPropertyChanged("BookName");
            }
        }

        public string Author
        {
            get { return _book.Author; }
            set
            {
                _book.Author= value;
                OnPropertyChanged("Author");
            }
        }

        public string Publisher
        {
            get { return _book.Publisher; }
            set
            {
                _book.Publisher = value;
                OnPropertyChanged("Publisher");
            }
        }

        public int Pages
        {
            get { return _book.Pages; }
            set
            {
                _book.Pages = value;
                OnPropertyChanged("Pages");
            }
        }

        public int GenreId
        {
            get { return _book.GenreId; }
            set
            {
                _book.GenreId = value;
                OnPropertyChanged("GenreId");
            }
        }

        public int Year
        {
            get { return _book.Year; }
            set
            {
                _book.Year = value;
                OnPropertyChanged("Year");
            }
        }

        public decimal CostPrice
        {
            get { return _book.CostPrice; }
            set
            {
                _book.CostPrice = value;
                OnPropertyChanged("CostPrice");
            }
        }

        public decimal Price
        {
            get { return _book.Price; }
            set
            {
                _book.Price = value;
                OnPropertyChanged("Price");
            }
        }

        public bool IsPartBookSeries
        {
            get { return _book.IsPartBookSeries; }
            set
            {
                _book.IsPartBookSeries = value;
                OnPropertyChanged("IsPartBookSeries");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
