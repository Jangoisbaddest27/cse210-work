using System;

// For the stretch challenge, the randomizer does not run for Word objects that have already been hidden.

class Program
{
    static void Main(string[] args)
    {
        // Create objects
        Reference newReference = new Reference("Proverbs", 3, 5, 6);
        Scripture newScripture = new Scripture();

        newScripture.SetScripture("Trust in the Lord with all thine heart; and lean not unto thine own understanding; In all thy ways acknowledge him, and he shall direct thy paths.");
        newScripture.ScripSplit();   // Populate list of Word objects
        // Set default values
        string userChoice = "";
        int hiddenCount = 0;

        while (userChoice != "quit")
        {
            Console.Clear();
            newReference.Display();   // Display reference
            // Display and edit each Word object
            foreach (var word in newScripture.GetWordList())
            {
                word.Display();
                Console.Write(" ");

                // Randomize if word is hidden in next loop
                if (word.GetIsHidden() == false)
                {
                    Random randomGenerator = new Random();
                    int random = randomGenerator.Next(0,999);
                    if (random >= 500)   // 50% chance of being hidden
                    {
                        word.SetIsHidden(true);   // Change to hidden
                        ++hiddenCount;   // Count number of hidden Word objects
                    }
                }
            }
            Console.Write(Environment.NewLine + "Press enter to continue or type 'quit' to finish: ");
            // Break from while loop after final display of hidden words
            if (hiddenCount == (1 + newScripture.GetWordList().Count))
            {
                break;
            }

            else if (hiddenCount == newScripture.GetWordList().Count)
            {
                ++hiddenCount;
            }
            // User enter or "quit"
            userChoice = Console.ReadLine();
        }
    }
}