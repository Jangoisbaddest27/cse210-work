

public class ContinuousGoal : Goal
{
    public ContinuousGoal(string goalName, string goalDescription, int goalPoints, bool isCompleted) : base(goalName, goalDescription, goalPoints, isCompleted)
    {}

    public ContinuousGoal()
    {
        _goalName = "";
        _goalDescription = "";
        _goalPoints = 0;
        _isCompleted = false;
    }

    public override void CreateGoal()
    {
        Console.Write("What is the name of your goal? ");
        _goalName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _goalDescription = Console.ReadLine();
        Console.Write("How many points is this goal worth? ");
        string points = Console.ReadLine();
        _goalPoints = int.Parse(points);
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {_goalName} ({_goalDescription})");
    }

    public override string SaveGoal()
    {
        string line = $"ContinuousGoal:{_goalName}|{_goalDescription}|{_goalPoints}";
        return line;
    }

    public override int IsCompleted()
    {
        return _goalPoints;
    }
}