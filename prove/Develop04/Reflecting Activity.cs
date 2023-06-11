

public class ReflectingActivity : Activity
{
    private List<string> _questions;
    private List<string> _prompts;
    
    public ReflectingActivity(List<string> prompts, List<string> questions, string activityName, string activityMessage) : base(activityName, activityMessage)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public string _RandomPrompt()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0,3);
        return _prompts[number];
    }

    public string _RandomQuestion()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0,8);
        return _questions[number];
    }

    public void _DisplayReflectingCountdown()
    {
        Console.Clear();
        Console.Write("\nGet ready");
        _DotDotDotTimer();
        _DotDotDotTimer();

        Console.WriteLine("\n\nConsider the following prompt:");
        Console.WriteLine($" --- {_RandomPrompt()} --- ");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in...");
        _NumberTimer(999);

        Console.Clear();
        DateTime currentTime = DateTime.Now;
        // Console.WriteLine(currentTime);
        DateTime endTime = currentTime.AddSeconds(_activityDuration);
        // Console.WriteLine(endTime);
        while (currentTime < endTime)
        {
            Console.Write($"\n> {_RandomQuestion()} ");
            _SpinnerTimer();
            _SpinnerTimer();
            _SpinnerTimer();
            _SpinnerTimer();
            _SpinnerTimer();
            _SpinnerTimer();
            _SpinnerTimer();
            _SpinnerTimer();
            _SpinnerTimer();
            _SpinnerTimer();    

            currentTime = DateTime.Now;
        }
        Console.WriteLine();
    }
}