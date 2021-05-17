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
    class AccountViewModel : INotifyPropertyChanged
    {
        private Account _account;
        public AccountViewModel(Account account)
        {
            _account = account;
        }

        public int Id
        {
            get { return _account.Id; }
            set
            {
                _account.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public int TypeAccountId
        {
            get { return _account.TypeAccountId; }
            set
            {
                _account.TypeAccountId = value;
                OnPropertyChanged("TypeAccountId");
            }
        }

        public string Login
        {
            get { return _account.Login; }
            set
            {
                _account.Login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Passw
        {
            get { return _account.Passw; }
            set
            {
                _account.Passw = value;
                OnPropertyChanged("Passw");
            }
        }

        public string FIO
        {
            get { return _account.FIO; }
            set
            {
                _account.FIO = value;
                OnPropertyChanged("FIO");
            }
        }

        public long Phone
        {
            get { return _account.Phone; }
            set
            {
                _account.Phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Email
        {
            get { return _account.Email; }
            set
            {
                _account.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}