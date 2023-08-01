using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class NoteTakingApp
{
    private static List<Note> notes;
    private const string NotesFileName = "notes.json";

    public static void Main(string[] args)
    {
        notes = LoadNotes();
        ShowMenu();
    }

    private static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nNote-Taking Application");
            Console.WriteLine("1. Add Note");
            Console.WriteLine("2. View Notes");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddNote();
                        break;
                    case 2:
                        ViewNotes();
                        break;
                    case 3:
                        SaveNotes();
                        Console.WriteLine("Exiting the application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    private static void AddNote()
    {
        Console.Write("Enter note title: ");
        string title = Console.ReadLine();

        Console.Write("Enter note content: ");
        string content = Console.ReadLine();

        Note newNote = new Note(title, content);
        notes.Add(newNote);
        Console.WriteLine("Note added successfully.");
    }

    private static void ViewNotes()
    {
        Console.WriteLine("\nAll Notes:");
        foreach (var note in notes)
        {
            Console.WriteLine($"Title: {note.Title}");
            Console.WriteLine($"Content: {note.Content}");
            Console.WriteLine($"Creation Date: {note.CreationDate}");
            Console.WriteLine();
        }
    }

    private static List<Note> LoadNotes()
    {
        try
        {
            if (File.Exists(NotesFileName))
            {
                string json = File.ReadAllText(NotesFileName);
                return JsonConvert.DeserializeObject<List<Note>>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading notes: {ex.Message}");
        }

        return new List<Note>();
    }

    private static void SaveNotes()
    {
        try
        {
            string json = JsonConvert.SerializeObject(notes, Formatting.Indented);
            File.WriteAllText(NotesFileName, json);
            Console.WriteLine("Notes saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving notes: {ex.Message}");
        }
    }
}
