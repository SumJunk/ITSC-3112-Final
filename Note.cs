using System;

public class Note
{
  
    public int Nid { get; private set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Position { get; set; }


    public Note(int id, string title, string content, string position)
    {
        Nid = id;
        Title = title;
        Content = content;
        Position = position;
    }

  
    public override string ToString()
    {
        return $"{Nid}|{Title}|{Content}|{Position}";
    }

    
    public static Note FromString(string data)
    {
        var parts = data.Split('|');
        if (parts.Length != 4)
        {
            throw new FormatException("Invalid note format in data.");
        }

        return new Note(
            int.Parse(parts[0]),    
            parts[1],               
            parts[2],               
            parts[3]               
        );
    }
}
