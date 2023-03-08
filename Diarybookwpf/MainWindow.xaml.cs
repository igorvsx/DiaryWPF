using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Diarybookwpf
{
    public partial class MainWindow : Window
    {
        private List<Note> notes = new List<Note>();
        
        private string notesFilePath = "C:\\Users\\Igor\\Desktop\\notes.json";
        public MainWindow()
        {
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Today;
            if (File.Exists(notesFilePath))
            {
                notes.Clear();
                notes = JsonClass<List<Note>>.Deserialize<List<Note>>("notes.json");

                ShowNotesForSelectedDate();
            }
            else
            {
                notes = new List<Note>();
            }
        }
        private void SaveNotesToFile()
        {
            JsonClass<List<Note>>.Serialize(notes, "notes.json");
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
                SaveNotesToFile();

                ShowNotesForSelectedDate();
            }
            else
            {
                MessageBox.Show("Заметка не может быть пустой");
            }
        }
        private void ShowNoteDetails()
        {
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
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteNote();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            AddNote();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateNote();
        }
    }
}