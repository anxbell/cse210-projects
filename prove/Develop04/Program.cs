using System;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Menu();
    }

    public void Menu()
    {
        BreathingActivity breathing = new BreathingActivity();
        ReflectionActivity reflection = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();
        VisualizationActivity visualization = new VisualizationActivity();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start visualization activity");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    breathing.StartActivity();
                    break;
                case "2":
                    reflection.StartActivity();
                    break;
                case "3":
                    listing.StartActivity();
                    break;
                case "4":
                    visualization.StartActivity();
                    break;
                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
