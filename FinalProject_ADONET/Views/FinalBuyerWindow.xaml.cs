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

namespace FinalProject_ADONET.Views
{
    /// <summary>
    /// Логика взаимодействия для FinalBuyerWindow.xaml
    /// </summary>
    public partial class FinalBuyerWindow : Window
    {
        bool CardStatus = false;
        bool MonthStatus = false;
        bool YearStatus = false;
        bool CvvStatus = false;
        bool PhoneStatus = false;

        public FinalBuyerWindow(decimal allPrice)
        {
            InitializeComponent();
            allPriceLabel.Content = $"Сумма к оплате : {(int)allPrice} грн.";
        }

        private void card_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(card.Text))
            {
                foreach (var i in card.Text)
                {
                    if (Char.IsDigit(i))
                    {
                        CardStatus = true;
                    }
                    else { CardStatus = false; break; }
                }
                if (CardStatus == true && card.Text.Length == 16)
                {
                    cardStatus.Content = "✅"; cardStatus.Foreground = Brushes.Green;
                }
            }
            else
            {
                cardStatus.Content = "❌";
                cardStatus.Foreground = Brushes.Red;
                CardStatus = false;
            }
        }

        private void month_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(month.Text))
            {
                foreach (var i in month.Text)
                {
                    if (Char.IsDigit(i))
                    {
                        if (Convert.ToInt32(month.Text) <= 12)
                        {
                            MonthStatus = true;
                        }
                        else { MonthStatus = false; break; }
                    }
                    else { MonthStatus = false; break; }
                }
                if (MonthStatus == true)
                {
                    if (month.Text.ToString().Length == 1 || (month.Text.ToString().Length == 2))
                    {
                        statusMonth.Content = "✅"; statusMonth.Foreground = Brushes.Green;
                    }
                    else
                    {
                        statusMonth.Content = "❌";
                        statusMonth.Foreground = Brushes.Red;
                        MonthStatus = false;
                    }
                }
                else
                {
                    statusMonth.Content = "❌";
                    statusMonth.Foreground = Brushes.Red;
                    MonthStatus = false;
                }
            }
            else
            {
                statusMonth.Content = "❌";
                statusMonth.Foreground = Brushes.Red;
                MonthStatus = false;
            }
        }

        private void year_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(year.Text))
            {
                foreach (var i in year.Text)
                {
                    if (Char.IsDigit(i))
                    {
                        if (int.Parse(year.Text.ToString()) >= 2021)
                            YearStatus = true;
                    }
                    else { YearStatus = false; break; }
                }
                if (YearStatus == true)
                {
                    if (year.Text.ToString().Length == 4)
                    {
                        statusYear.Content = "✅"; statusYear.Foreground = Brushes.Green;
                    }
                    else
                    {
                        statusYear.Content = "❌";
                        statusYear.Foreground = Brushes.Red;
                        YearStatus = false;
                    }
                }
                else
                {
                    statusYear.Content = "❌";
                    statusYear.Foreground = Brushes.Red;
                    YearStatus = false;
                }
            }
            else
            {
                statusYear.Content = "❌";
                statusYear.Foreground = Brushes.Red;
                YearStatus = false;
            }
        }

        private void cvv_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(cvv.Text))
            {
                foreach (var i in cvv.Text)
                {
                    if (Char.IsDigit(i))
                    {
                            CvvStatus = true;
                    }
                    else { CvvStatus = false; break; }
                }
                if (CvvStatus == true)
                {
                    if (cvv.Text.ToString().Length == 3)
                    {
                        cvvStatus.Content = "✅"; cvvStatus.Foreground = Brushes.Green;
                    }
                    else
                    {
                        cvvStatus.Content = "❌";
                        cvvStatus.Foreground = Brushes.Red;
                        CvvStatus = false;
                    }
                }
                else
                {
                    cvvStatus.Content = "❌";
                    cvvStatus.Foreground = Brushes.Red;
                   CvvStatus = false;
                }
            }
            else
            {
                cvvStatus.Content = "❌";
                cvvStatus.Foreground = Brushes.Red;
                CvvStatus = false;
            }
        }

        private void phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(phone.Text))
            {
                foreach (var i in phone.Text)
                {
                    if (Char.IsDigit(i))
                    {
                        PhoneStatus = true;
                    }
                    else { PhoneStatus = false; break; }
                }
                if (PhoneStatus == true && phone.Text.Length == 12)
                {
                    phoneStatus.Content = "✅"; phoneStatus.Foreground = Brushes.Green;
                }
                else
                {
                    phoneStatus.Content = "❌";
                    phoneStatus.Foreground = Brushes.Red;
                    PhoneStatus = false;
                }
            }
            else
            {
                phoneStatus.Content = "❌";
                phoneStatus.Foreground = Brushes.Red;
                PhoneStatus = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (CardStatus == true &&
            MonthStatus == true &&
            YearStatus == true &&
            CvvStatus == true &&
            PhoneStatus == true && addres.Text.Length > 5)
            {
                MessageBox.Show("Вы успешно оформили заказ ожидайте зваонка менеджера", "Поздравляем !");
                this.Close();
            }
        }
    }
}
