using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class NoteManager
{
    private List<Note> notes;

    public NoteManager()
    {
        notes = new List<Note>();
        LoadNotes();
    }

 
    public void CreateNote(string title, string content, string position)
    {
   
        int positionValue = string.IsNullOrWhiteSpace(position) || !int.TryParse(position, out int result) ? 0 : result;

        
        if (notes.Any(note => note.Position == positionValue.ToString()))
        {
            Console.WriteLine($"Error: A note already exists with position {positionValue}. Please choose a different position.");
            return;
        }

        
        int newId = notes.Count > 0 ? notes.Max(note => note.Nid) + 1 : 1;
        Note newNote = new Note(newId, title, content, positionValue.ToString());
        notes.Add(newNote);

       
        SortNotesByPosition();

        Console.WriteLine($"Note '{title}' created successfully with Id: '{newNote.Nid}'.");
    }

    
    public void DeleteNote(int noteId)
    {
        Note noteToDelete = FindNoteById(noteId);
        if (noteToDelete != null)
        {
            notes.Remove(noteToDelete);
            Console.WriteLine($"Note with ID {noteId} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Note with ID {noteId} not found.");
        }
    }

    
    public Note FindNoteById(int noteId)
    {
        return notes.FirstOrDefault(note => note.Nid == noteId);
    }

    
    public void EditNote(int noteId, string newTitle, string newContent, string newPosition)
    {
        Note noteToEdit = FindNoteById(noteId);
        if (noteToEdit != null)
        {
            noteToEdit.Title = newTitle;
            noteToEdit.Content = newContent;

            
            if (!string.IsNullOrWhiteSpace(newPosition) && int.TryParse(newPosition, out int newPositionValue))
            {
                noteToEdit.Position = newPositionValue.ToString();
            }

            
            SortNotesByPosition();

            Console.WriteLine($"Note with ID {noteId} updated successfully.");
        }
        else
        {
            Console.WriteLine($"Note with ID {noteId} not found.");
        }
    }

    
    private void SortNotesByPosition()
    {
        notes = notes.OrderBy(note => int.Parse(note.Position)).ToList();
    }

    
    public void SaveNotes()
    {
        using (StreamWriter writer = new StreamWriter("notes.txt"))
        {
            foreach (var note in notes)
            {
                writer.WriteLine($"{note.Nid}|{note.Title}|{note.Content}|{note.Position}");
            }
        }
    }

    
    public void LoadNotes()
    {
        if (File.Exists("notes.txt"))
        {
            string[] lines = File.ReadAllLines("notes.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                notes.Add(new Note(int.Parse(parts[0]), parts[1], parts[2], parts[3]));
            }

            
            SortNotesByPosition();
        }
    }


    public List<Note> GetNotes()
    {
        return notes;
    }
}
