

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference (string book, int chapter, int verse)   // Single verse
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0;
    }

    public Reference (string book, int chapter, int verse, int endVerse)   // Multiple verses
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public void Display()
    {
        if (_endVerse == 0)   // Single verse
        {
            Console.WriteLine($"{_book} {_chapter}:{_verse}");
        }

        else   // Multiple verses
        {
            Console.WriteLine($"{_book} {_chapter}:{_verse}-{_endVerse}");
        }
    }
}