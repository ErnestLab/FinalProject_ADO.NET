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
    class GenreViewModel : INotifyPropertyChanged
    {
        private Genre _genre;
        public GenreViewModel(Genre genre)
        {
            _genre = genre;
        }

        public int Id
        {
            get { return _genre.Id; }
            set
            {
                _genre.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _genre.Name; }
            set
            {
                _genre.Name = value;
                OnPropertyChanged("BookName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}