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

namespace FitTrack
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private User user;

        public UserDetailsWindow(User user)
        {
            InitializeComponent();
            this.user = user ?? throw new ArgumentNullException(nameof(user)); // Kasta ett undantag om user är null

        }

        private void Confirm_Btn_Click(object sender, RoutedEventArgs e)
        {
            //hämtar användardetaljer från användarens inmatningar
            string newUsername = Newuser.Text;
            string newPassword = Newpass.Password;
            string confirmPassword = Confirmpass.Password;
            string newCountry = (CountryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // validerar inmatningarna
            if (string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newPassword) || newPassword != confirmPassword)
            {
                MessageBox.Show("Please enter valid details and ensure passwords match.");
                return;
            }

            // Updaterar användarens detaljer (namn och lösen)
            user.Username = newUsername;
            if (!string.IsNullOrEmpty(newPassword))
            {
                user.Password = newPassword;
            }
            user.Country = newCountry;

            this.DialogResult = true; //Funkar det? spara och stäng.



        }
    }
}
