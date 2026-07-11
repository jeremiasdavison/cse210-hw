using System;

class Entry
{
    public string _date;
    public string _prompt;
    
    public string _response;

    public string Display()
    {
        string text = _date + "\n" + _prompt + "\n" + _response + "\n";
        return text;
    }
}
