using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using System.Linq;

//{d:SampleData ItemCount=5}
namespace Diarybookwpf
{
    public partial class MainWindow : Window
    {

        private List<Note> notes = new List<Note>();
        private string notesFilePath = "C:\\Users\\Igor\\Desktop\\notes.json";
        public MainWindow()
        {
            InitializeComponent();
            datePicker.Text = DateTime.Today.ToString();
            datePicker.DisplayDate = DateTime.Today;
            if (File.Exists(notesFilePath))
            {
                notes.Clear();
                string json = File.ReadAllText(notesFilePath);
                notes = JsonConvert.DeserializeObject<List<Note>>(json);
                //foreach (Note note in notes)
                //{
                //    MessageBox.Show(note.ToString());
                //}
                //datePicker.SelectedDate = selectedDate;

                ShowNotesForSelectedDate();
            }
            else
            {
                notes = new List<Note>();
            }
        }
        private void SaveNotesToFile()
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText(notesFilePath, json);
        }

        private void ShowNotesForSelectedDate()
        {
            notesList.Items.Clear();
            noteTitle.Text = "";
            noteDescription.Text = "";
            DateTime selectedDate = datePicker.SelectedDate.GetValueOrDefault();
            if (notes != null)
            {
                foreach (Note note in notes)
                {
                    if (selectedDate == note.Date)
                    {

                        notesList.Items.Add(note.Title);

                    }
                }
            }


        }
        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            notesList.SelectionChanged -= notesList_SelectionChanged;
            //noteTitle.Text = "";
            //noteDescription.Text = "";
            //notesList.Items.Clear();
            //DateTime selectedDate = datePicker.SelectedDate.GetValueOrDefault();
            //foreach (Note note in notes)
            //{
            //    if (/*Convert.ToDateTime(datePicker.SelectedDate).Day == note.Date.Day*/selectedDate == note.Date)
            //    {
            //        notesList.Items.Add(note.Title);
            //    }
            //}
            //selectedDate = datePicker.SelectedDate ?? DateTime.Today;
            ShowNotesForSelectedDate();
            notesList.SelectionChanged += notesList_SelectionChanged;
        }
        private void UpdateNote()
        {
            if (notesList.SelectedItem != null)
            {
                Note note = notes[notesList.SelectedIndex];
                note.Title = noteTitle.Text;
                note.Description = noteDescription.Text;
                ShowNotesForSelectedDate();
                SaveNotesToFile();
            }
        }
        private void DeleteNote()
        {
            notes.RemoveAt(notesList.SelectedIndex);
            ShowNotesForSelectedDate();
            SaveNotesToFile();
        }
        private void AddNote()
        {
            //List<Note> new_notes = new List<Note>();
            //List<Note> old_notes = new List<Note>();
            DateTime selectedDate = datePicker.SelectedDate.GetValueOrDefault();
            if (noteTitle.Text != "" & noteDescription.Text != "")
            {
                Note note = new Note();
                note.Title = noteTitle.Text;
                note.Description = noteDescription.Text;
                note.Date = selectedDate;
                if (notes == null)
                {
                    notes = new List<Note>();
                }
                notes.Add(note);
                //{
                //    Title = noteTitle.Text,
                //    Description = noteDescription.Text,
                //    Date = selectedDate
                //};
                //foreach (string item in sourceList)
                //{
                //    if (targetList == null)
                //    {
                //        targetList = new List<string>();
                //    }

                //    targetList.Add(item);
                //}
                //if (notes == null)
                //{
                //    new_notes.Add(note);
                //    notes.AddRange(new_notes);
                //}
                //else
                //{
                //    notes.Add(note);
                //}

                SaveNotesToFile();

                // Show notes for selected date
                ShowNotesForSelectedDate();
            }
            else
            {
                MessageBox.Show("Заметка не может быть пустой");
            }
        }
        private void ShowNoteDetails()
        {
            //ShowNotesForSelectedDate();
            Note note = notes[notesList.SelectedIndex];
            noteTitle.Text = note.Title;
            noteDescription.Text = note.Description;
        }
        private void notesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (notesList.SelectedIndex >= 0)
            {
                ShowNoteDetails();
            }
            //foreach (Note note in notes)
            //{
            //    if (notesList.SelectedItem.ToString() == note.Title)
            //    {
            //        //Note note = (Note)notesList.SelectedItem;

            //        noteTitle.Text = note.Title;
            //        noteDescription.Text = note.Description;
            //    }
            //}

            //if (notesList.SelectedItem != null)
            //{
            //    Note note = (Note)notesList.SelectedItem;

            //    noteTitle.Text = note.Title;
            //    noteDescription.Text = note.Description;
            //}
            //else
            //{
            //    // Clear note details
            //    noteTitle.Text = "";
            //    noteDescription.Text = "";
            //}
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //var selectedNoteTitle = (string)notesList.SelectedValue;
            //var selectedNote = notes.FirstOrDefault(n => n.Title == selectedNoteTitle);

            //if (selectedNote == null)
            //{
            //    MessageBox.Show("Выберите заметку для удаления", "Ошибка");
            //    return;
            //}

            //notes.Remove(selectedNote);
            //SaveNotesToFile();
            //ShowNotesForSelectedDate();

            DeleteNote();

            //if (notesList.SelectedItem != null)
            //{
            //    var selectedNote = (Note)notesList.SelectedItem;
            //    notes.Remove(selectedNote);
            //    //DateTime selectedDate = datePicker.SelectedDate.GetValueOrDefault();

            //    //foreach (Note note in notes)
            //    //{
            //    //    if (notesList.SelectedItem.ToString() == note.Title)
            //    //    {
            //    //        notesList.Items.Remove(note);
            //    //        notes.Remove(note);
            //    //        SaveNotesToFile();
            //    //        notesList.Items.Clear();
            //    //    }
            //    //}
            //    SaveNotesToFile();
            //    ShowNotesForSelectedDate();
            //}
            //else
            //{
            //    MessageBox.Show("Выберите дату, у которой хотите удалить заметку");
            //}

            //if (notesList.SelectedItem != null)
            //{
            //    // Delete selected note
            //    Note note = (Note)notesList.SelectedItem;
            //    notes.Remove(note);

            //    // Save notes to file
            //    SaveNotesToFile();

            //    // Show notes for selected date
            //    ShowNotesForSelectedDate();
            //}

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            AddNote();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateNote();
            //if (notesList.SelectedItem != null)
            //{
            //    Note note = notes[notesList.SelectedIndex];
            //    note.Title = noteTitle.Text;
            //    note.Description = noteDescription.Text;
            //    //ShowNotes();
            //    //SaveNotes();
            //    // Update selected note
            //    //Note note = (Note)notesList.SelectedItem;
            //    //note.Title = noteTitle.Text;
            //    //note.Description = noteDescription.Text;
            //    ShowNotesForSelectedDate();
            //    SaveNotesToFile();
            //    // Save notes to file
            //    //

            //    //// Show notes for selected date
            //    //
            //}
        }
    }
}