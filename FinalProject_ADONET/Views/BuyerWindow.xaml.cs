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
        OperationsViewModel ovm = new OperationsViewModel();
        decimal allPrice = 0;
        public BuyerWindow()
        {
            InitializeComponent();
            this.DataContext = ovm;
        }
        private void addBook_Click(object sender, RoutedEventArgs e)
        {
            if (books.SelectedItem != null)
            {
                addedBooks.Items.Add(books.SelectedItem as BooksViewModel);
                allPrice = 0;
                foreach (BooksViewModel i in addedBooks.Items)
                    allPrice += i.Price;
                priceLabel.Content = $"Ваша корзина: {allPrice}";
            }
        }
        private void delBook_Click(object sender, RoutedEventArgs e)
        {
            if (addedBooks.SelectedItem as BooksViewModel != null)
            {
                addedBooks.Items.Remove(addedBooks.SelectedItem);
                allPrice = 0;
                foreach (BooksViewModel i in addedBooks.Items)
                    allPrice += i.Price;
                priceLabel.Content = $"Ваша корзина: {allPrice}";
            }
        }

        private void buyBook_Click(object sender, RoutedEventArgs e)
        {
            if (allPrice > 0)
            {
                FinalBuyerWindow fbw = new FinalBuyerWindow(allPrice);
                fbw.ShowDialog();
                addedBooks.Items.Clear();
            }
        }
    }
}
