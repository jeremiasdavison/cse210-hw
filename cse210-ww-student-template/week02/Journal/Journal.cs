using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
   public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.Display());
        }
    }

    public void SaveToFile(string filename)
    {
        StreamWriter outputFile = new StreamWriter(filename);

        foreach (Entry entry in _entries)
        {
            string line = entry._date;
            line = line + "~|~";
            line = line + entry._prompt;
            line = line + "~|~";
            line = line + entry._response;

            outputFile.WriteLine(line);
        }

        outputFile.Close();
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            Entry loadedEntry = new Entry();
            loadedEntry._date = parts[0];
            loadedEntry._prompt = parts[1];
            loadedEntry._response = parts[2];

            _entries.Add(loadedEntry);
        }
    }
}