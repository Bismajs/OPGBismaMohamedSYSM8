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
    /// Interaction logic for WorkoutsWindow.xaml
    /// </summary>
    public partial class WorkoutsWindow : Window
    {
        private User currentUser;
        public WorkoutsWindow(User user)
        {
            InitializeComponent();
            currentUser = user; // akttuella användaren

            // Lägg till STANDARDanvändarens träningspass i workoutlist

            foreach (var workout in currentUser.Workouts)
            {
                workoutlist.Items.Add(workout);
            }
    }

    private void Signout_btn_Click(object sender, RoutedEventArgs e)
        {
            //navigerar tillbaka till mainwindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AddWorkout_btn_Click(object sender, RoutedEventArgs e)
        {
            // Skapa en instans av addworkout fönstret
            AddWorkoutWindow addWorkoutsWindow = new AddWorkoutWindow();
            if (addWorkoutsWindow.ShowDialog() == true) //öppnar fönstret som ett nytt fönster ovanpå
            {
                // Hämta det nya passet
                var workout = addWorkoutsWindow.NewWorkout;

                // Kontrollera att workout inte är null
                if (workout != null) 
                {
                    workoutlist.Items.Add(workout); //lägg till pass frpn listan
                }
            }

        }

        private void RemoveWorkout_btn_Click(object sender, RoutedEventArgs e)
        {
            if (workoutlist.SelectedItem != null) // ser till att ett pass är valt/klickat
            {
                workoutlist.Items.Remove(workoutlist.SelectedItem); //ta bort pass frpn listan
            }
            else
            {
                MessageBox.Show("Please select a workout to remove."); //ifall inget pass ärr valt
            }
        }


        private void Details_btn_Click(object sender, RoutedEventArgs e)
        {
            if (workoutlist.SelectedItem is Workout selectedWorkout) // ser till att ett pass är valt/klickat
            {
                WorkoutDetailsWindow detailsWindow = new WorkoutDetailsWindow(selectedWorkout);
                detailsWindow.ShowDialog(); //öppnar fönstret som ett nytt fönster ovanpå
                RefreshWorkoutList(); // Uppdatera listan för att visa ändringar
            }
            else
            {
                MessageBox.Show("Please select a workout to Open."); //ifall inget pass ärr valt
            }

        }

        private void Profile_btn_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)  // ser till att användaren inte är null
            {
                UserDetailsWindow userDetailsWindow = new UserDetailsWindow(currentUser);
                if (userDetailsWindow.ShowDialog() == true) //öppnar fönstret som ett nytt fönster ovanpå
                {
                    // jajamän, vill man göra detta?
                }
            }
            else
            {
                MessageBox.Show("User information is not available."); //användarinfo saknas
            }


        }

        //metod som uppdaterar listan över apss
        private void RefreshWorkoutList()
        {
            workoutlist.Items.Refresh(); 
        }
    }
}
