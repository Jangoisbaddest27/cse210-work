

public class Activity
{
    protected string _activityName;
    protected string _activityMessage;
    protected int _activityDuration;
    protected int _activityTotal;

    public Activity(string activityName, string activityMessage)
    {
        _activityName = activityName;
        _activityMessage = activityMessage;
        _activityDuration = 0;
        _activityTotal = 0;
    }

    public int _GetActivityTotal()
    {
        return _activityTotal;
    }

    public void _DisplayStart()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity");
        Console.WriteLine($"\n{_activityMessage}");
        Console.Write("\nHow long, in seconds, would you like your session to be? ");
        string duration = Console.ReadLine();
        _activityDuration = int.Parse(duration);
        _activityTotal = _activityTotal + _activityDuration;
    }

    public void _DotDotDotTimer()
    {
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write("\b \b");
        Thread.Sleep(500);
        Console.Write("\b \b");
        Thread.Sleep(500);
        Console.Write("\b \b");
        Thread.Sleep(500);
    }

    public void _SpinnerTimer()
    {
        Console.Write("|");
        Thread.Sleep(250);
        Console.Write("\b/");
        Thread.Sleep(250);
        Console.Write("\b-");
        Thread.Sleep(250);
        Console.Write("\b\\");
        Thread.Sleep(250);
        Console.Write("\b \b");
    }

    public void _NumberTimer(int remainder)
    {
        if (remainder >= 5)
        {
            Console.Write("5");
            Thread.Sleep(1000);
        }
        else    // Space to be overwritten if "5" was not written.
        {
            Console.Write(" ");
        }
        if (remainder >= 4)
        {
            Console.Write("\b4");
            Thread.Sleep(1000);
        }
        if (remainder >= 3)
        {
            Console.Write("\b3");
            Thread.Sleep(1000);
        }
        if (remainder >= 2)
        {
            Console.Write("\b2");
            Thread.Sleep(1000);
        }
        if (remainder >= 1)
        {
            Console.Write("\b1");
            Thread.Sleep(1000);
        }
        Console.Write("\b \n");
    }

    public void _DisplayEnd()
    {
        Console.WriteLine("\nVery good!");
        _SpinnerTimer();
        _SpinnerTimer();
        _SpinnerTimer();
        Console.WriteLine($"\nYou have completed {_activityDuration} seconds of the {_activityName} Activity.");
        _SpinnerTimer();
        _SpinnerTimer();
        _SpinnerTimer();
        Console.Clear();
    }
}