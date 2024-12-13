using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Initiera standardanvändare
            UserManager.InitializeDefaultUsers();
        }

        private void NavigateToForgotPasswordWindow(object sender, RoutedEventArgs e)
        {
            //navigerar till forgotpasswordwindow
            ForgotPasswordWindow forgotPasswordWindow = new ForgotPasswordWindow();
            forgotPasswordWindow.Show();
            this.Close(); // Stäng aktuellt fönster
        }

        //navigerar till workoutwindow
        private void NavigateToWorkoutsWindow(object sender, RoutedEventArgs e)
        {
            // Hämta användarnamn och lösenord från inputrutorr
            string username = username_Txb.Text;
            string password = passwordBox.Password;

            // Validerar användarnamn och lösenror
            if (UserManager.ValidateUser(username, password))
            {
                // Login Funkar, Hämtar User object
                User authenticatedUser = UserManager.GetUserByUsername(username);

                // Öppnar workoutswindow 
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(authenticatedUser);
                workoutsWindow.Show();
                this.Close(); // Stäng aktuellt fönster
            }
            else
            {
                // fel inputs i rutoorna
                MessageBox.Show("Fel användarnamn eller lösenord.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        //navigerar till registerfönstret

        private void NavigateToRegisterWindow(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close(); // Stäng aktuellt fönster
        }
    }
}