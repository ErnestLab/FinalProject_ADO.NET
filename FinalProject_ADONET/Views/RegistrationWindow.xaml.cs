using FinalProject_ADONET.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FinalProject_ADONET.Views
{
    public partial class RegistrationWindow : Window
    {
        DataManager dm = new DataManager();

        bool succes;
        private DispatcherTimer timer = null;
        private int countTimer = 5;

        bool FioStatus = false;
        bool PhoneStatus = false;
        bool EmailStatus = false;
        bool LoginStatus = false;
        bool PasswStatus = false;

        public RegistrationWindow()
        {
            InitializeComponent();
            FIO.Focus();
        }

        private void FIO_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (!String.IsNullOrWhiteSpace(FIO.Text))
            {
                if (FIO.Text.Contains(" ") && FIO.Text.Length > 5) 
                {
                    foreach(var i in FIO.Text)
                    {
                        if (Char.IsLetter(i) || i.ToString() == " ")
                        {
                            FioStatus = true;
                        }
                        else { FioStatus = false; break; }
                    }
                    if (FioStatus)
                    { fioStatus.Content = "✅"; fioStatus.Foreground = Brushes.Green; }

                    else
                    {
                        fioStatus.Content = "❌";
                        fioStatus.Foreground = Brushes.Red;
                        PhoneStatus = false;
                    }
                }
                else
                {
                    fioStatus.Content = "❌";
                    fioStatus.Foreground = Brushes.Red;
                    PhoneStatus = false;
                }

            }
            else
            {
                fioStatus.Content = "❌";
                fioStatus.Foreground = Brushes.Red;
            }


        }

        private void phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(phone.Text))
            {
                foreach(var i in phone.Text)
                {
                    if (Char.IsDigit(i))
                    {
                        PhoneStatus = true;
                    }
                    else { PhoneStatus = false; break; }
                }
                if(PhoneStatus == true && phone.Text.Length == 12)
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

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(email.Text))
            {
                if (email.Text.Contains("@gmail.com") || email.Text.Contains("@yahoo.com")
                    || email.Text.Contains("@ukr.net") || email.Text.Contains("@outlook.com"))
                    EmailStatus = true;
                else
                {
                    emailStatus.Content = "❌";
                    emailStatus.Foreground = Brushes.Red;
                    EmailStatus = false;
                }

                if (EmailStatus == true && email.Text.Length > 5)
                {
                    emailStatus.Content = "✅"; emailStatus.Foreground = Brushes.Green;
                }
                else
                {
                    emailStatus.Content = "❌";
                    emailStatus.Foreground = Brushes.Red;
                    EmailStatus = false;
                }
            }
            else
            {
                emailStatus.Content = "❌";
                emailStatus.Foreground = Brushes.Red;
                EmailStatus = false;
            }
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(login.Text))
            {
                if(Regex.IsMatch(login.Text, @"^[a-zA-Z0-9]+$") && login.Text.Length > 5)
                {
                    LoginStatus = true;
                    loginStatus.Content = "✅"; loginStatus.Foreground = Brushes.Green;
                }
                else
                {
                    loginStatus.Content = "❌";
                    loginStatus.Foreground = Brushes.Red;
                    LoginStatus = false;
                }
            }
            else
            {
                loginStatus.Content = "❌";
                loginStatus.Foreground = Brushes.Red;
                LoginStatus = false;
            }
        }

        private void passw_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(passw.Password))
            {
                if (Regex.IsMatch(passw.Password, @"^[a-zA-Z0-9_]+$") && passw.Password.Length >= 8)
                {
                    PasswStatus = true;
                    passwStatus.Content = "✅"; passwStatus.Foreground = Brushes.Green;
                }
                else
                {
                    passwStatus.Content = "❌";
                    passwStatus.Foreground = Brushes.Red;
                    PasswStatus = false;
                }
            }
            else
            {
                passwStatus.Content = "❌";
                passwStatus.Foreground = Brushes.Red;
                PasswStatus = false;
            }
        }

        private void registrationEnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (FioStatus == true && PhoneStatus == true && EmailStatus == true
                && LoginStatus == true && PasswStatus == true)
            {
                string newFIO = FIO.Text;
                long newPhone = long.Parse(phone.Text);
                string newEmail = email.Text;
                string newLogin = login.Text;
                string newPassw = GetMd5Hash(passw.Password);


                dm.Accounts.Add(new Models.Account()
                {
                    FIO = newFIO,
                    Phone = newPhone,
                    Email = newEmail,
                    Login = newLogin,
                    Passw = newPassw,
                    TypeAccountId = 1
                });
              
                statusRegistration.Foreground = Brushes.Green;
                statusRegistration.Content = $"Успешно регестрация через : {countTimer}";

                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 250);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();

                dm.SaveChanges();
            }
        }



        private void timer_Tick(object sender, EventArgs e)
        {
            if (succes)
            {
                statusRegistration.Content = $"Успешно регестрация через : {countTimer}";
            }
            if (countTimer == 0) { timer.Stop();  this.Close(); };

            countTimer--;
        }
        private string GetMd5Hash(string target)
        {
            MD5 encoder = MD5.Create();
            byte[] buff = Encoding.UTF8.GetBytes(target);
            byte[] data = encoder.ComputeHash(buff);

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            string result = sBuilder.ToString();

            return result;
        }



        private void FIO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) phone.Focus();
        }
        private void phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) email.Focus();
        }
        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) login.Focus();
        }
        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) passw.Focus();
        }
    }
}
