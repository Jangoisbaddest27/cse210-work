

public class BreathingActivity : Activity
{
    public BreathingActivity(string activityName, string activityMessage) : base(activityName, activityMessage)
    {}

    public void _DisplayBreathingCountdown()
    {
        Console.Clear();
        Console.Write("\nGet ready");
        _DotDotDotTimer();
        _DotDotDotTimer();
        Console.WriteLine();

        int remainder = _activityDuration % 10;
        DateTime currentTime = DateTime.Now;
        // Console.WriteLine(currentTime);
        DateTime endTime = currentTime.AddSeconds(_activityDuration - remainder);
        // Console.WriteLine(endTime);
        while (currentTime < endTime)
        {
            Console.Write("\nBreathe in...");
            _NumberTimer(999);
            Console.Write("Now breathe out...");
            _NumberTimer(999);
            currentTime = DateTime.Now;
        }
        Console.Write("\nBreathe in...");
        _NumberTimer(remainder);
        if (remainder > 5)
        {
            Console.Write("Now breathe out...");
            _NumberTimer(remainder - 5);
        }
    }
}
