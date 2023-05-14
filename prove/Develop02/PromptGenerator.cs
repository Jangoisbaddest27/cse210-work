

public class PromptGenerator
{
    static string prompt1 = "What made you smile today?";
    static string prompt2 = "Who were you happy to spend time with today?";
    static string prompt3 = "What do you want to do better tomorrow?";
    static string prompt4 = "What did you learn today?";
    static string prompt5 = "What are you grateful for today?";
    static string prompt6 = "What did you do today that you are proud of?";
    static string prompt7 = "What memories did today bring to your mind?";
    static string prompt8 = "What was the weather like today?";
    static string prompt9 = "Who would you like to spend time with tomorrow?";
    static string prompt10 = "Name two bad things and three good things that happened today?";
    public List<string> _prompts = new List<string>{prompt1, prompt2, prompt3, prompt4, prompt5, prompt6, prompt7, prompt8, prompt9, prompt10};

    public string RandomPrompt()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0,9);
        return _prompts[number];
    }
}