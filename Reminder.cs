
public class Reminder
{
    public int Rid { get; private set; }
    public DateTime Date { get; set; }
    public int FNid { get; private set; } 

    public Reminder(int id, DateTime date, int noteId)
    {
        Rid = id;
        Date = date;
        FNid = noteId;
    }


    public override string ToString()
    {
        return $"{Rid}|{Date}|{FNid}";
    }


    public static Reminder FromString(string data)
    {
        var parts = data.Split('|');
        if (parts.Length != 3)
        {
            throw new FormatException("Invalid reminder format in data.");
        }

        return new Reminder(
            int.Parse(parts[0]),     
            DateTime.Parse(parts[1]), 
            int.Parse(parts[2])       
        );
    }

 
    public void EditReminder(DateTime newDate)
    {
        Date = newDate;
    }
}








