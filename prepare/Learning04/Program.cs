using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment simpleAssignment = new Assignment("Nicholas Johnson", "Science");
        Console.WriteLine(simpleAssignment.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("Ashton Howard", "Geometry", "10.9", "27-38");
        Console.WriteLine(Environment.NewLine + mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment = new WritingAssignment("Stephen Caringer", "US History", "The State of our Nation");
        Console.WriteLine(Environment.NewLine + writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInfo());
    }
}