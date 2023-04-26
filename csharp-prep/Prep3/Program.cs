using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.Write("What is the magic number? ");
        //string userInput = Console.ReadLine();
        //int number = int.Parse(userInput);
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,100);
        string userInput = "";
        int guess = 0;

        do
        {
            Console.Write("What is your guess? ");
            userInput = Console.ReadLine();
            guess = int.Parse(userInput);

            if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (guess != number);
    }
}