using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = 1;

        do
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        int total = 0;
        int largest = 0;
        int smallest = 999;

        foreach (int value in numbers)
        {
            total = total + value;
            if (value > largest)
            {
                largest = value;
            }
            if (value < smallest && value > 0)
            {
                smallest = value;
            }
        }

        var sortedNumbers = numbers.OrderBy(value => value);

        float average = ((float)total) / numbers.Count;
        Console.WriteLine($"The sume is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");
        Console.WriteLine("The sorted list is:");

        foreach (int value in sortedNumbers)
        {
            Console.WriteLine(value);
        }
    }
}