using FinalProject_ADONET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FinalProject_ADONET.Models;

namespace FinalProject_ADONET.Views
{
    /// <summary>
    /// Логика взаимодействия для BuyerWindow.xaml
    /// </summary>
    public partial class BuyerWindow : Window
    {
        OperationsViewModel ovm;
        List<BooksViewModel> BooksInOrder = new List<BooksViewModel>();
        BooksViewModel SelectedBookInOrder = new BooksViewModel(new Book() { });

        public BuyerWindow()
        {
            InitializeComponent();
            ovm = new OperationsViewModel();
            this.DataContext = ovm;
            addedBooks.DisplayMemberPath = "BookName";
        }

        private void addBook_Click(object sender, RoutedEventArgs e)
        {
            if (ovm.SelectedBook != null)
            {
                BooksInOrder.Add(ovm.SelectedBook);
                addedBooks.ItemsSource = BooksInOrder;
            }
        }

        private void delBook_Click(object sender, RoutedEventArgs e)
        {
            if(addedBooks.SelectedItem as BooksViewModel != null)
            BooksInOrder.Remove(addedBooks.SelectedItem as BooksViewModel);
        }

        private void addedBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
