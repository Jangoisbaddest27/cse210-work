using System.IO; 

public class Entry
{
    public string _date;
    public string _prompt;
    public string _userResponse;

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"{_userResponse}");
        Console.WriteLine();
    }
}