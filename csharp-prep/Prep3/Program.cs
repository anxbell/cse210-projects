using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {   

        Random randomGenerator = new Random();


        string response = "yes";

        while (response == "yes") {

            int magicn = randomGenerator.Next(1, 100);
            Console.WriteLine(magicn);

            int guess = -1;

            int attempts = 0;

            while (guess != magicn ) {

                Console.Write("What's your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicn > guess )
                {
                    Console.WriteLine("Higher");
                }

                else if ( magicn == guess)
                {

                    Console.WriteLine("You guessed it!");
                }

                else {

                    Console.WriteLine("Lower");

                }

                attempts++;


            }

            Console.WriteLine($"Number of guesses {attempts}");

            Console.Write("Do you want to continue? ");
            response = Console.ReadLine();



        }
    }  
}