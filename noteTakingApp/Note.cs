using System;

public class Note
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }

    public Note(string title, string content)
    {
        Title = title;
        Content = content;
        CreationDate = DateTime.Now;
    }
}
