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
    /// Interaction logic for ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow : Window
    {
        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        private void NavigateToLogin2(object sender, RoutedEventArgs e)
        {
            // Hämta inmatning
            string username = Username_txb.Text.Trim();
            string newPassword = newpass_txb.Text.Trim();
            string securityAnswer = Securityans_txb.Text.Trim();
            string selectedQuestion = ((ComboBoxItem)question_box.SelectedItem)?.Content.ToString(); // Hämta vald säkerhetsfråga

            // Se till att alla fält är ifyllda
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(securityAnswer) || selectedQuestion == null)
            {
                MessageBox.Show("Vänligen fyll i alla fält.");
                return;
            }

            // Validerar säkerhetsfrågan och återställer lösenordet
            bool isReset = UserManager.ResetPassword(username, securityAnswer, newPassword);

            if (isReset)
            {
                MessageBox.Show("Lösenordet har uppdaterats. Du kan nu logga in med ditt nya lösenord.");
                NavigateToLogin(); // Navigera tillbaka till inloggning
            }
            else
            {
                MessageBox.Show("Felaktigt användarnamn eller svar på säkerhetsfrågan.");
            }
        }

        // Navigera tillbaka till mainwindow
        private void NavigateToLogin()
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); // Stäng aktuellt fönster
        }

        // Koppla Submit-knappen till rätt metod
        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigateToLogin2(sender, e);
        }
    }
}
