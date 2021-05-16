using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FinalProject_ADONET.Models;
using System.Collections.ObjectModel;
using FinalProject_ADONET.EF;
using FinalProject_ADONET.Commands;
using System.Windows;
using System.Data.Entity;

namespace FinalProject_ADONET.ViewModels
{
    class OperationsViewModel : INotifyPropertyChanged
    {
        private DataManager dm = new DataManager();

        public ObservableCollection<AccountViewModel> Accounts { get; set; }
        public ObservableCollection<BooksViewModel> Books { get; set; }
        public ObservableCollection<GenreViewModel> Genres { get; set; }
        public ObservableCollection<StockViewModel> Stocks { get; set; }
        public ObservableCollection<TypeAccountViewModel> TypeAccounts { get; set; }

        private AccountViewModel _selectedAccount;
        public AccountViewModel SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                OnPropertyChanged("SelectedAccount");
            }
        }

        private BooksViewModel _selectedBook;
        public BooksViewModel SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        private GenreViewModel _selectedGenre;
        public GenreViewModel SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                _selectedGenre = value;
                LoadBooks(_selectedGenre.Id);
                OnPropertyChanged("SelectedGenre");
            }
        }

        private StockViewModel _selectedStock;
        public StockViewModel SelectedStock
        {
            get { return _selectedStock; }
            set
            {
                _selectedStock = value;
                OnPropertyChanged("SelectedStock");
            }
        }

        private TypeAccountViewModel _selectedTypeAccount;
        public TypeAccountViewModel SelectedTypeAccount
        {
            get { return _selectedTypeAccount; }
            set
            {
                _selectedTypeAccount = value;
                OnPropertyChanged("SelectedTypeAccount");
            }
        }

        public OperationsViewModel()
        {
            Accounts = new ObservableCollection<AccountViewModel>();
            Books = new ObservableCollection<BooksViewModel>();
            Genres = new ObservableCollection<GenreViewModel>();
            Stocks = new ObservableCollection<StockViewModel>();
            TypeAccounts = new ObservableCollection<TypeAccountViewModel>();

            LoadGenres();
        }

        private RelayCommand _addGenre;
        public RelayCommand AddGenre
        {
            get
            {
                return _addGenre ?? (_addGenre = new RelayCommand(obj =>
                {
                    Genre genre = new Genre()
                    {
                        Id = 0, Name = "Новый жанр"
                    };
                    GenreViewModel genre_vm = new GenreViewModel(genre);
                    Genres.Add(genre_vm);
                    SelectedGenre = genre_vm;
                }));
            }
        }

        private RelayCommand _saveGenre;
        public RelayCommand SaveGenre
        {
            get
            {
                return _saveGenre ?? (_saveGenre = new RelayCommand(obj =>
                {
                    Genre saveGenre = obj as Genre;
                    if (saveGenre != null)
                    {
                        if (saveGenre.Id == 0)
                        {
                            dm.Genres.Add(saveGenre);
                            dm.SaveChanges();
                            MessageBox.Show("Жанр успешно добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            var editGenre = dm.Genres.Where(g => g.Id == saveGenre.Id).FirstOrDefault();
                            editGenre.Name = saveGenre.Name;
                            dm.Entry(editGenre).State = EntityState.Modified;
                            dm.SaveChanges();
                            MessageBox.Show("Жанр успешно изменен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }));
            }
        }

        private RelayCommand _delGenre;
        public RelayCommand DelGenre
        {
            get
            {
                return _delGenre ?? (_delGenre = new RelayCommand(obj =>
                {
                    Genre delGenre = obj as Genre;
                    if (delGenre != null && delGenre.Id != 0)
                    {
                        Genres.Remove(SelectedGenre);
                        dm.Genres.Remove(delGenre);
                        dm.SaveChanges();
                        MessageBox.Show("Жанр успешно удален", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("Жанр не определен или не сохранен в базе", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }));
            }
        }

        private RelayCommand _addTypeAccount;
        public RelayCommand AddTypeAccount
        {
            get
            {
                return _addTypeAccount ?? (_addTypeAccount = new RelayCommand(obj =>
                {
                    TypeAccount typeAccount = new TypeAccount()
                    {
                        Id = 0, Name = "Новый тип аккаунта"
                    };
                    TypeAccountViewModel typeAccount_vm = new TypeAccountViewModel(typeAccount);
                    TypeAccounts.Add(typeAccount_vm);
                    SelectedTypeAccount = typeAccount_vm;
                }));
            }
        }

        private RelayCommand _saveTypeAccount;
        public RelayCommand SaveTypeAccount
        {
            get
            {
                return _saveTypeAccount ?? (_saveTypeAccount = new RelayCommand(obj =>
                {
                    TypeAccount saveTypeAccount = obj as TypeAccount;
                    if (saveTypeAccount != null)
                    {
                        if (saveTypeAccount.Id == 0)
                        {
                            dm.TypeAccounts.Add(saveTypeAccount);
                            dm.SaveChanges();
                            MessageBox.Show("Тип аккаунта успешно добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            var editTypeAccount = dm.TypeAccounts.Where(ta => ta.Id == saveTypeAccount.Id).FirstOrDefault();
                            editTypeAccount.Name = saveTypeAccount.Name;
                            dm.Entry(editTypeAccount).State = EntityState.Modified;
                            dm.SaveChanges();
                            MessageBox.Show("Тип аккаунта успешно изменен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }));
            }
        }

        private RelayCommand _delTypeAccount;
        public RelayCommand DelTypeAccount
        {
            get
            {
                return _delTypeAccount ?? (_delTypeAccount = new RelayCommand(obj =>
                {
                    TypeAccount delTypeAccount = obj as TypeAccount;
                    if (delTypeAccount != null && delTypeAccount.Id != 0)
                    {
                        TypeAccounts.Remove(SelectedTypeAccount);
                        dm.TypeAccounts.Remove(delTypeAccount);
                        dm.SaveChanges();
                        MessageBox.Show("Тип аккаунта успешно удален", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("Тип аккаунта не определен или не сохранен в базе", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }));
            }
        }

        private RelayCommand _addBook;
        public RelayCommand AddBook
        {
            get
            {
                return _addBook ?? (_addBook = new RelayCommand(obj =>
                {
                    Genre selGenre = obj as Genre;
                    if (Books.Count == 0)
                    {
                        Books.Clear();
                    }
                    Book newBook = new Book()
                    {
                        Id = 0, BookName = "Новая книга", Author = "Новый автор", Publisher = "Новый издатель",
                        Pages = 0, GenreId = selGenre.Id, Year = 0, CostPrice = 0, Price = 0, IsPartBookSeries = false
                    };
                    BooksViewModel books_vm = new BooksViewModel(newBook);
                    Books.Add(books_vm);
                    SelectedBook = books_vm;
                }));
            }
        }

        private RelayCommand _saveBook;
        public RelayCommand SaveBook
        {
            get
            {
                return _saveBook ?? (_saveBook = new RelayCommand(obj =>
                {
                    Book saveBook = obj as Book;
                    Genre selGenre = obj as Genre;
                    if (saveBook != null)
                    {
                        if (saveBook.Id == 0)
                        {
                            dm.Books.Add(saveBook);
                            dm.SaveChanges();
                            MessageBox.Show("Книга успешно добавлена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            var editBook = dm.Books.Where(b => b.Id == saveBook.Id).FirstOrDefault();
                            editBook.BookName = saveBook.BookName;
                            editBook.Author = saveBook.Author;
                            editBook.Publisher = saveBook.Publisher;
                            editBook.Pages = saveBook.Pages;
                            editBook.GenreId = selGenre.Id;
                            editBook.Year = saveBook.Year;
                            editBook.CostPrice = saveBook.CostPrice;
                            editBook.Price = saveBook.Price;
                            editBook.IsPartBookSeries = saveBook.IsPartBookSeries;
                            dm.Entry(editBook).State = EntityState.Modified;
                            dm.SaveChanges();
                            MessageBox.Show("Книга успешно измененa", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }));
            }
        }

        private RelayCommand _delBook;
        public RelayCommand DelBook
        {
            get
            {
                return _delBook ?? (_delBook = new RelayCommand(obj =>
                {
                    Book delBook = obj as Book;
                    if (delBook != null && delBook.Id != 0)
                    {
                        Books.Remove(SelectedBook);
                        dm.Books.Remove(delBook);
                        dm.SaveChanges();
                        MessageBox.Show("Книга успешно удалена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("Книга не определена или не сохраненa в базе", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }));
            }
        }

        private RelayCommand _addStock;
        public RelayCommand AddStock
        {
            get
            {
                return _addStock ?? (_addStock = new RelayCommand(obj =>
                {
                    Book selBook = obj as Book;
                    Stock stock = new Stock()
                    {
                        Percent = 0, BookId = selBook.Id
                    };
                    StockViewModel stock_vm = new StockViewModel(stock);
                    Stocks.Add(stock_vm);
                    SelectedStock = stock_vm;
                }));
            }
        }

        private RelayCommand _saveStock;
        public RelayCommand SaveStock
        {
            get
            {
                return _saveStock ?? (_saveStock = new RelayCommand(obj =>
                {
                    Stock saveStock = obj as Stock;
                    Book selBook = obj as Book;
                    if (saveStock != null)
                    {
                        if (saveStock.Id == 0)
                        {
                            dm.Stocks.Add(saveStock);
                            dm.SaveChanges();
                            MessageBox.Show("Акция успешно добавлена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            var editStock = dm.Stocks.Where(s => s.Id == saveStock.Id).FirstOrDefault();
                            editStock.Percent = saveStock.Percent;
                            editStock.BookId = selBook.Id;
                            dm.Entry(editStock).State = EntityState.Modified;
                            dm.SaveChanges();
                            MessageBox.Show("Акция успешно измененa", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }));
            }
        }

        private RelayCommand _delStock;
        public RelayCommand DelStock
        {
            get
            {
                return _delStock ?? (_delStock = new RelayCommand(obj =>
                {
                    Stock delStock = obj as Stock;
                    if (delStock != null && delStock.Id != 0)
                    {
                        Stocks.Remove(SelectedStock);
                        dm.Stocks.Remove(delStock);
                        dm.SaveChanges();
                        MessageBox.Show("Акция успешно удалена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("Акция не определена или не сохраненa в базе", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }));
            }
        }

        private void LoadGenres()
        {
            Genres.Clear();
            var genresFromDb = dm.Genres.ToList();
            foreach (var genre in genresFromDb)
                Genres.Add(new GenreViewModel(genre));
        }

        private void LoadBooks(int gid)
        {
            Books.Clear();
            var booksFilteredByGenre = dm.Books.Where(b => b.GenreId == gid).ToList();
            foreach (var book in booksFilteredByGenre)
                Books.Add(new BooksViewModel(book));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
