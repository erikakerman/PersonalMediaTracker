using System.Collections.Generic;

class Book
{
    private List<string> titles = new List<string>();

    public void AddTitle(string title)
    {
        titles.Add(title);
    }
}