using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write ("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int userGrade = int.Parse(userInput);
        int lastDigit = (userGrade % 10);

        string letter = "";

        if (userGrade >= 90)
        {
            letter = "A";
            //Console.WriteLine("A");
        }
        else if (userGrade >= 80)
        {
            letter = "B";
            //Console.WriteLine("B");
        }
        else if (userGrade >= 70)
        {
            letter = "C";
            //Console.WriteLine("C");
        }
        else if (userGrade >= 60)
        {
            letter = "D";
            //Console.WriteLine("D");
        }
        else
        {
            letter = "F";
            //Console.WriteLine("F");
        }

        string sign = "";

        if (lastDigit >= 7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }
        else if (lastDigit < 3 && letter != "F")
        {
            sign = "-";
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (userGrade >= 70)
        {
            Console.WriteLine("Well done, you passed the class!");
        }
        else
        {
            Console.WriteLine("You can pass when you try again next time!");
        }
    }
}