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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace Diarybookwpf
{
    public partial class MainWindow : Window
    {
        private List<Note> notes = new List<Note>();
        private string notesFilePath = "C:\\Users\\Igor\\Desktop\\notes.json";
        private DateTime selectedDate = DateTime.Today;
        public MainWindow()
        {
            InitializeComponent();
            //DatePick.Text = DateTime.Today.ToString();
            //DatePick.DisplayDate = DateTime.Today;
            if (File.Exists(notesFilePath))
            {
                string json = File.ReadAllText(notesFilePath);
                notes = JsonConvert.DeserializeObject<List<Note>>(json);
            }

            // Set default date to today
            datePicker.SelectedDate = selectedDate;

            // Show notes for default date
            ShowNotesForSelectedDate();
        }
        private void SaveNotesToFile()
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText(notesFilePath, json);
        }

        private void ShowNotesForSelectedDate()
        {
            // Clear existing notes
            notesList.Items.Clear();

            // Show notes for selected date
            foreach (Note note in notes)
            {
                if (note.Date == selectedDate)
                {
                    notesList.Items.Add(note);
                }
            }
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = datePicker.SelectedDate ?? DateTime.Today;
            ShowNotesForSelectedDate();
        }

        private void notesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (notesList.SelectedItem != null)
            {
                // Show selected note details
                Note note = (Note)notesList.SelectedItem;
                noteTitle.Text = note.Title;
                noteDescription.Text = note.Description;
            }
            else
            {
                // Clear note details
                noteTitle.Text = "";
                noteDescription.Text = "";
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (notesList.SelectedItem != null)
            {
                // Delete selected note
                Note note = (Note)notesList.SelectedItem;
                notes.Remove(note);

                // Save notes to file
                SaveNotesToFile();

                // Show notes for selected date
                ShowNotesForSelectedDate();
            }

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (noteTitle.Text != "" & noteDescription.Text != "")
            {
                Note note = new Note
                {
                    Title = noteTitle.Text,
                    Description = noteDescription.Text,
                    Date = selectedDate
                };
                notes.Add(note);
                SaveNotesToFile();

                // Show notes for selected date
                ShowNotesForSelectedDate();
            }
            else
            {
                MessageBox.Show("Заметка не может быть пустой");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (notesList.SelectedItem != null)
            {
                // Update selected note
                Note note = (Note)notesList.SelectedItem;
                note.Title = noteTitle.Text;
                note.Description = noteDescription.Text;

                // Save notes to file
                SaveNotesToFile();

                // Show notes for selected date
                ShowNotesForSelectedDate();
            }
        }
    }
}
