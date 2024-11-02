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
    /// Interaction logic for WorkoutDetailsWindow.xaml
    /// </summary>
    public partial class WorkoutDetailsWindow : Window
    {
       
        private Workout workout;
        public WorkoutDetailsWindow(Workout selectedWorkout)
        {
            InitializeComponent();
            workout = selectedWorkout; 
            DisplayWorkoutDetails(); //visar detaljerna för passet
            LockInputs(); // lÅS INPUTRUTORNA

        }

        //Metod flr att visa detaljerna för ett valt pass
        private void DisplayWorkoutDetails()
        {
            DateTextBox.Text = workout.Date.ToShortDateString();
            DurationTextBox.Text = workout.Duration.ToString();
            TypeComboBox.Text = workout.Type;
            CaloriesTextBox.Text = workout.CaloriesBurned.ToString();
            NotesTextBox.Text = workout.Notes;

      //kontrollera typen av workout (strength eller cardio) för att visa relevant in
            if (workout is StrengthWorkout strengthWorkout)
            {
                RepsTextBox.Text = strengthWorkout.Repetitions.ToString();
                SetsTextBox.Visibility = Visibility.Visible; // Gör setstextbox synlig
            
            }
            else if (workout is CardioWorkout cardioWorkout)
            {
                DistanceTextBox.Text = cardioWorkout.Distance.ToString();
                DistanceTextBox.Visibility = Visibility.Visible;// Gör distancetextbox synlig
            }
        }

        //medot som låser inputfälten så att de inte kan redigeras
        private void LockInputs()
        {
            
            DateTextBox.IsReadOnly = true;
            DurationTextBox.IsReadOnly = true;
            TypeComboBox.IsEnabled = false;
            CaloriesTextBox.IsReadOnly = true;
            NotesTextBox.IsReadOnly = true;
            RepsTextBox.IsReadOnly = true;
            SetsTextBox.IsReadOnly = true;
            DistanceTextBox.IsReadOnly = true;
        }

        //medot som låser upp inputfälten så att de kan redigeras
        private void UnlockInputs()
        {
            
            DateTextBox.IsReadOnly = false;
            DurationTextBox.IsReadOnly = false;
            TypeComboBox.IsEnabled = true;
            CaloriesTextBox.IsReadOnly = false;
            NotesTextBox.IsReadOnly = false;
            RepsTextBox.IsReadOnly = false;
            SetsTextBox.IsReadOnly = false;
            DistanceTextBox.IsReadOnly = false;
        }


        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnlockInputs(); // aktiverar metoden som öppnar up de låsta inputrutorna
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            // spara ändringar till workoutfönstret 
            workout.Date = DateTime.Parse(DateTextBox.Text);
            workout.Duration = TimeSpan.Parse(DurationTextBox.Text);
            workout.Type = TypeComboBox.Text;
            workout.CaloriesBurned = int.Parse(CaloriesTextBox.Text);
            workout.Notes = NotesTextBox.Text;

            if (workout is StrengthWorkout strengthWorkout)
            {
                strengthWorkout.Repetitions = int.Parse(RepsTextBox.Text);
            }
            else if (workout is CardioWorkout cardioWorkout)
            {
                cardioWorkout.Distance = int.Parse(DistanceTextBox.Text);
            }

            this.DialogResult = true; // lyckas det, stäng fönstret

        }

    }
}
