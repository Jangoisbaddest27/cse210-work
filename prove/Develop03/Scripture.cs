

public class Scripture
{
    private string _scripture;
    private List<Word> _wordList = new List<Word>();
    private int index = 0;

    public string GetScripture()
    {
        return _scripture;
    }

    public void SetScripture(string scripture)
    {
        _scripture = scripture;
    }

    public List<Word> GetWordList()
    {
        return _wordList;
    }

    public void SetWordList(List<Word> words)
    {
        _wordList = words;
    }

    public void ScripSplit()
    {
        string[] words = _scripture.Split(' ');
        foreach (string word in words)
        {
            // Create Word object, add to list, increase index
            Word newWord = new Word (word, index);
            _wordList.Add(newWord);
            ++index;
        }
    }
}