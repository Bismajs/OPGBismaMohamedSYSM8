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
    /// Interaction logic for AddWorkoutWindow.xaml
    /// </summary>
    public partial class AddWorkoutWindow : Window
    {
        // Konstruktor som initialiserar fönstret
        public AddWorkoutWindow()
        {
            InitializeComponent();
        }

        // Egenskap för att lagra det nya träningspasset som ska skapas
        public Workout NewWorkout { get; private set; }

        // Händelsehanterare för knappen "Spara träningspass"
        private void SaveWorkout_btn_Click(object sender, RoutedEventArgs e)
        {
            // Försök att analysera datum från textfältet
            DateTime.TryParse(DateTextBox.Text, out DateTime date);

            // Försök att analysera varaktighet från textfältet
            TimeSpan.TryParse(DurationTextBox.Text, out TimeSpan duration);

            // Försök att analysera antalet brända kalorier från textfältet
            int.TryParse(CaloriesTextBox.Text, out int caloriesBurned);

            // Hämta anteckningar från textfältet
            string notes = NotesTextBox.Text;

            // Kontrollera om en träningskategori har valts i kombinationsrutan
            if (TypeComboBox.SelectedItem is ComboBoxItem selectedType)
            {
                // Hämta valt träningskategori som en sträng
                string workoutType = selectedType.Content.ToString();

                // Kontrollera om det är en styrketräning
                if (workoutType == "Strength")
                {
                    // Försök att analysera antal repetitioner från textfältet
                    int.TryParse(RepsTextBox.Text, out int repetitions);

                    // Skapa ett nytt StrengthWorkout-objekt med angivna värden
                    NewWorkout = new StrengthWorkout
                    {
                        Date = date,
                        Duration = duration,
                        CaloriesBurned = caloriesBurned,
                        Notes = notes,
                        Type = workoutType,
                        Repetitions = repetitions
                    };
                }
                // Kontrollera om det är ett konditionsträning
                else if (workoutType == "Cardio")
                {
                    // Försök att analysera distansen från textfältet
                    int.TryParse(DistanceTextBox.Text, out int distance);

                    // Skapa ett nytt CardioWorkout-objekt med angivna värden
                    NewWorkout = new CardioWorkout
                    {
                        Date = date,
                        Duration = duration,
                        CaloriesBurned = caloriesBurned,
                        Notes = notes,
                        Type = workoutType,
                        Distance = distance
                    };
                }

                // Ange dialogresultatet till true för att indikera att spara är klart och stäng fönstret
                DialogResult = true;
                Close();
            }
        }
    }

}
