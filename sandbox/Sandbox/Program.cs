using System;

class Program
{
    static string prompt1 = "What made you smile today?";
    static string prompt2 = "Who were you happy to spend time with today?";
    static string prompt3 = "What do you want to do better tomorrow?";
    public List<string> _prompts = new List<string>{prompt1, prompt2, prompt3};

    foreach (int prompt in _prompts)
        {
            Console.WriteLine(prompt);
        }
}