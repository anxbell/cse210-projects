using System;
using System.IO; 

class Program
{
    static void Main(string[] args)
    {
        
        Program program = new Program();
        program.Menu();

    }

    public void Menu() {

                Journal journal = new Journal();
        Prompts prompts = new Prompts();
        
        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Delete a specific entry");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Write(journal, prompts);
                    break;
                case "2":
                    Display(journal);
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    Save(journal, saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    Load(journal, loadFilename);
                    break;

                case "5":
                    Console.Write("Enter the title of the entry to delete: ");
                    string titleToDelete = Console.ReadLine();
                    Console.Write("Enter filename to delete entry: ");
                    string filename = Console.ReadLine();
                    journal.DeleteEntry(titleToDelete, filename);
                    break;  
                
                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }


    private void Write(Journal journal, Prompts prompts)
    {
        string prompt = prompts.GeneratePrompt();
        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Enter your response: ");
        string content = Console.ReadLine();
        Console.Write("Enter Journal Entry title: ");
        string title = Console.ReadLine();


        string date = DateTime.Now.ToString("MM/dd/yyyy");
        journal.AddEntry(title, date, prompt, content);
    }

    private void Display(Journal journal)
    {
        journal.DisplayEntries();
    }

    private void Save(Journal journal, string filename)
    {
        journal.Save(filename);
    }

    private void Load(Journal journal, string filename)
    {
        journal.Load(filename);
    }


}