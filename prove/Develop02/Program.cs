using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        int choice = 0;
        Journal newJournal = new Journal();
        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices.");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string userChoice = Console.ReadLine();
            choice = int.Parse(userChoice);
            string recentPrompt = "";

            if (choice == 1)    //Write
            {
                Entry newEntry = new Entry();
                newEntry._date = DateTime.Today.ToString();

                PromptGenerator newPrompt = new PromptGenerator();
                newEntry._prompt = newPrompt.RandomPrompt();

                //Prevent a repeat of the same prompt twice in a row
                while (newEntry._prompt == recentPrompt)
                {
                    newEntry._prompt = newPrompt.RandomPrompt();
                }
                recentPrompt = newEntry._prompt;

                Console.WriteLine($"{newEntry._prompt}");

                Console.Write("> ");
                newEntry._userResponse = Console.ReadLine();

                newJournal._entries.Add(newEntry); 
            }

            else if (choice == 2)   //Display
            {
                newJournal.DisplayJournal();
            }

            else if (choice == 3)   //Load
            {
                Console.Write("Enter the load file name: ");
                newJournal._loadFileName = Console.ReadLine();

                newJournal.LoadJournal();
            }

            else if (choice == 4)   //Save
            {
                Console.Write("Enter the save file name: ");
                newJournal._saveFileName = Console.ReadLine();

                newJournal.SaveJournal();
            }

            else    //Quit
            {
                Console.WriteLine("Have a good day!");
            }
        }
    }
}