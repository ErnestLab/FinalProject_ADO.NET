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
    class TypeAccountViewModel : INotifyPropertyChanged
    {
        private TypeAccount _typeAccount;
        public TypeAccountViewModel(TypeAccount typeAccount)
        {
            _typeAccount = typeAccount;
        }

        public int Id
        {
            get { return _typeAccount.Id; }
            set
            {
                _typeAccount.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _typeAccount.Name; }
            set
            {
                _typeAccount.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}