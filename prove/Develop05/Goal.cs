

public abstract class Goal
{
    protected string _goalName;
    protected string _goalDescription;
    protected int _goalPoints;
    protected bool _isCompleted;

    public Goal(string goalName, string goalDescription, int goalPoints, bool isCompleted)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _goalPoints = goalPoints;
        _isCompleted = isCompleted;
    }

    public Goal()
    {
        _goalName = "";
        _goalDescription = "";
        _goalPoints = 0;
        _isCompleted = false;
    }

    public bool GetIsCompleted()
    {
        return _isCompleted;
    }

    public void SetIsCompleted(bool _bool)
    {
        _isCompleted = _bool;
    }

    public abstract void CreateGoal();

    public abstract void DisplayGoal();

    public abstract string SaveGoal();

    public abstract int IsCompleted();
}