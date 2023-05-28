

public class Word
{
    private string _word;
    private int _index;
    private bool _isHidden;

    public Word(string word, int index, bool isHidden)
    {
        _word = word;
        _index = index;
        _isHidden = isHidden;

    }
    
    public Word(string word, int index)
    {
        _word = word;
        _index = index;
        _isHidden = false;
    }

    public string GetWord()
    {
        return _word;
    }

    public void SetWord(string word)
    {
        _word = word;
    }

    public int GetIndex()
    {
        return _index;
    }

    public void SetIndex(int index)
    {
        _index = index;
    }

    public bool GetIsHidden()
    {
        return _isHidden;
    }

    public void SetIsHidden(bool isHidden)
    {
        _isHidden = isHidden;
    }

    public void Display()
    {
        if (_isHidden == true)
        {
            // Display "_" for each letter in Word object
            for (int letter = 1; letter <= _word.Length; ++letter)
            {
                Console.Write("_");
            }
        }

        else if (_isHidden == false)
        {
            Console.Write(_word);
        }
    }

}