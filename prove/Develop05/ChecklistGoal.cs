

public class ChecklistGoal : Goal
{
    private int _goalCurrentCount;
    private int _goalFinalCount;
    private int _goalBonus;

    public ChecklistGoal(string goalName, string goalDescription, int goalPoints, int goalCurrentCount, int goalFinalCount, int goalBonus, bool isCompleted) : base(goalName, goalDescription, goalPoints, isCompleted)
    {
        _goalCurrentCount = goalCurrentCount;
        _goalFinalCount = goalFinalCount;
        _goalBonus = goalBonus;
        _isCompleted = isCompleted;
    }

    public ChecklistGoal()
    {
        _goalName = "";
        _goalDescription = "";
        _goalPoints = 0;
        _goalCurrentCount = 0;
        _goalFinalCount = 0;
        _goalBonus = 0;
        _isCompleted = false;
    }

    public override void CreateGoal()
    {
        Console.Write("What is the name of your goal? ");
        _goalName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _goalDescription = Console.ReadLine();
        Console.Write("How many points is this goal worth? ");
        string number = Console.ReadLine();
        _goalPoints = int.Parse(number);
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        number = Console.ReadLine();
        _goalFinalCount = int.Parse(number);
        Console.Write("What is the value of this bonus? ");
        number = Console.ReadLine();
        _goalBonus = int.Parse(number);
    }

    public override void DisplayGoal()
    {
        if (_isCompleted == false)
        {
            Console.WriteLine($"[ ] {_goalName} ({_goalDescription}) -- Completed: {_goalCurrentCount}/{_goalFinalCount}");
        }

        else
        {
            Console.WriteLine($"[X] {_goalName} ({_goalDescription}) -- Completed: {_goalCurrentCount}/{_goalFinalCount}");
        }
        
    }

    public override string SaveGoal()
    {
        string line = $"ChecklistGoal:{_goalName}|{_goalDescription}|{_goalPoints}|{_goalCurrentCount}|{_goalFinalCount}|{_goalBonus}";
        return line;
    }

    public override int IsCompleted()
    {
        ++_goalCurrentCount;
        if (_goalCurrentCount == _goalFinalCount)
        {
            _isCompleted = true;
            return _goalPoints + _goalBonus;
        }

        else
        {
            return _goalPoints;
        }    
    }
}