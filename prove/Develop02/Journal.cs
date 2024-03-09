public class Journal
{
    // This is the member variable
    public List<Entry> _entries = new List<Entry>();

    // These are the methods
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
            string promptText = entry._promptText.Replace("\"", "\"\"").Replace(",", "~");
            string entryText = entry._entryText.Replace("\"", "\"\"").Replace(",", "~");
            outputFile.WriteLine($"{entry._date},{promptText},{entryText}");
            }
            // I looked up different sites to help me with this. I found this 
            // https://stackoverflow.com/questions/8090759/how-to-write-a-value-which-contain-comma-to-a-csv-file-in-c
            // but it gave me issues when loading the file. I checked with chatGPT as well and with a combination
            // of both, I arrived at the above solution. I learned about escaping characters
            // and the .Replace method.
        }
    }
    public void LoadFromFile(string file)
    {
        string[] lines = System.IO.File.ReadAllLines(file);
        foreach (string line in lines)
        {
            Entry entry = new Entry();
            string[] parts = line.Split(",");
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];
            if (parts[1].Contains("\"\"") || parts[1].Contains("~"))
            {
                entry._promptText = parts[1].Replace("\"\"", "\"").Replace("~", ",");
            }

            if (parts[2].Contains("\"\"") || parts[2].Contains("~"))
            {
                entry._entryText = parts[2].Replace("\"\"", "\"").Replace("~", ",");
            }

            _entries.Add(entry);
        }
    }

}