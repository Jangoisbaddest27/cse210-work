

public class SingleGoal : Goal
{
    public SingleGoal(string goalName, string goalDescription, int goalPoints, bool isCompleted) : base(goalName, goalDescription, goalPoints, isCompleted)
    {}

    public SingleGoal()
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
        if (_isCompleted == false)
        {
            Console.WriteLine($"[ ] {_goalName} ({_goalDescription})");
        }

        else
        {
            Console.WriteLine($"[X] {_goalName} ({_goalDescription})");
        }
    }

    public override string SaveGoal()
    {
        string line = $"SingleGoal:{_goalName}|{_goalDescription}|{_goalPoints}|{_isCompleted}";
        return line;
    }

    public override int IsCompleted()
    {
        _isCompleted = true;
        return _goalPoints;
    }
}