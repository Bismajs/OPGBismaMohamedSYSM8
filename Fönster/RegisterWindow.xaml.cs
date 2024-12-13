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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void NavigateToLogin(object sender, RoutedEventArgs e)
        {
            //hämtar inmatningar från användaren
            string username = Username_Txb.Text.Trim();
            string password = Password_Bx.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string country = Countrycombox.SelectedItem.ToString();
            string securityQuestion = (Security_box.SelectedItem as ComboBoxItem)?.Content.ToString();
            string securityAnswer = Securityan_tbx.Text.Trim(); // Anta att du har ett inputfält för svaret

            //kontrollera så att lösenorden i båda rutorna matchar
            if (password == confirmPassword)
            {
                //Registrerar användaren via usermanager
                if (UserManager.RegisterUser(username, password, country, securityQuestion, securityAnswer))
                {
                    MessageBox.Show("Registreringen lyckades!");

                    // Stäng registreringsfönstret och navigera till mainwindow
                    MainWindow mainWindow = new MainWindow(); 
                    mainWindow.Show(); 
                    this.Close(); // Stäng aktuellt fönster
                }
                else //om användarnamnet är uppdaget
                {
                    MessageBox.Show("Användarnamnet är redan upptaget.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else // om lösenorden inte matchar
            {
                MessageBox.Show("Lösenorden matchar inte.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
