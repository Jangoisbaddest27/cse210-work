using System.IO; 
public class Journal
{
    public string _saveFileName;
    public string _loadFileName;
    public List<Entry> _entries = new List<Entry>();

     public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveJournal()
    {
        using (StreamWriter outputFile = new StreamWriter(_saveFileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._userResponse}");
            }
        }
    }

    public void LoadJournal()
    {
        string[] lines = System.IO.File.ReadAllLines(_loadFileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry newEntry = new Entry();
            newEntry._date = parts[0];
            newEntry._prompt = parts[1];
            newEntry._userResponse = parts[2];

            _entries.Add(newEntry);
        }
    }
}