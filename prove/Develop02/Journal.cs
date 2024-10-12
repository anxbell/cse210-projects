using System;
using System.IO; 

public class Journal
{

    public List<Entry> _entries = new List<Entry>();


    public void AddEntry(string title, string date, string prompt, string content) {

        Entry entry = new Entry(title, date, prompt, content);
        _entries.Add(entry); 



        
    }
    
    public void DisplayEntries() {

        Console.WriteLine("\n---- Journal Entries ----");

        foreach (Entry entry in _entries) {
            

             entry.Display();
        }
    }

    //     public void Save(string filename) {

    //         //https://www.c-sharpcorner.com/article/csharp-streamwriter-example/ -- example of use

    //     using (StreamWriter writer = new StreamWriter(filename))
    //     {//StreamWriter.WriteLine() writes a string to the next line of the steam.

    //         foreach (Entry entry in _entries)
    //         {
    //             // csv
    //             writer.WriteLine($"{entry._title},{entry._date},{entry._content}");
    //         }
    //     }
    // }
    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._title}|{entry._date}|{entry._prompt}|{entry._content}");
            }
        }
        Console.WriteLine("Entries saved successfully.");
    }


public void Load(string filename)
{
    if (!File.Exists(filename))
    {
        Console.WriteLine("File not found.");
        return;
    }

    using (StreamReader reader = new StreamReader(filename))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            // Split the line by '|'
            string[] parts = line.Split('|');
            if (parts.Length >= 4)
            {
                string title = parts[0];
                string date = parts[1];
                string prompt = parts[2];
                string content = parts[3];

                // Check if the entry already exists before adding
                bool entryExists = false;
                foreach (Entry entry in _entries)
                {
                    if (entry._title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        entryExists = true;
                        break; // No need to continue checking if a duplicate is found
                    }
                }

                if (!entryExists)
                {
                    AddEntry(title, date, prompt, content);
                }

            }
        }
    }

    Console.WriteLine($"Entries from '{filename}' loaded successfully.\n");
}



public void DeleteEntry(string title, string filename)
{
    Entry entryToRemove = null;

    foreach (Entry entry in _entries)
    {
        if (entry._title.Equals(title, StringComparison.OrdinalIgnoreCase))
        {
            entryToRemove = entry;  
            break;
        }
    }

    if (entryToRemove != null)
    {
        _entries.Remove(entryToRemove);
        Console.WriteLine($"Entry titled '{title}' has been deleted.");
        Save(filename);
    }
    else
    {
        Console.WriteLine($"No entry found with the title '{title}'.");
    }
}


}