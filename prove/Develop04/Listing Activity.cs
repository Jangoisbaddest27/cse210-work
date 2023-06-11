

public class ListingActivity : Activity
{
    private List<string> _prompts;
    
    public ListingActivity(List<string> prompts, string activityName, string activityMessage) : base(activityName, activityMessage)
    {
        _prompts = prompts;
    }

    public string _RandomPrompt()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0,4);
        return _prompts[number];
    }

    public void _DisplayListingCountdown()
    {
        Console.Clear();
        Console.Write("\nGet ready");
        _DotDotDotTimer();
        _DotDotDotTimer();

        Console.WriteLine("\n\nList as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {_RandomPrompt()} --- ");
        Console.Write("You may begin in...");
        _NumberTimer(999);

        DateTime currentTime = DateTime.Now;
        // Console.WriteLine(currentTime);
        DateTime endTime = currentTime.AddSeconds(_activityDuration);
        // Console.WriteLine(endTime);
        int responseCount = 0;
        while (currentTime < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            ++responseCount;
            currentTime = DateTime.Now;
        }
        Console.WriteLine($"You listed {responseCount} responses!");
    }
}