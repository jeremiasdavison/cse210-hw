using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitText = text.Split(' ');
        foreach (string word in splitText)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> stillShowing = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                stillShowing.Add(word);
            }
        }

        for (int i = 0; i < numberToHide && stillShowing.Count > 0; i++)
        {
            int randomIndex = random.Next(stillShowing.Count);
            stillShowing[randomIndex].Hide();
            stillShowing.RemoveAt(randomIndex);
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public int CountHiddenWords()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                count++;
            }
        }

        return count;
    }

    public int CountTotalWords()
    {
        return _words.Count;
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        string referenceText = _reference.GetDisplayText();
        string verseText = string.Join(" ", displayWords);

        return $"{referenceText}\n{verseText}";
    }
}
