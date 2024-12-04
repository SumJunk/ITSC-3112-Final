using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ReminderManager
{
    private List<Reminder> reminders;

    public ReminderManager()
    {
        reminders = new List<Reminder>();
        LoadReminders();
    }


    public void AddReminder(int noteId, DateTime date)
    {
        int newId = reminders.Count > 0 ? reminders.Max(r => r.Rid) + 1 : 1;
        Reminder newReminder = new Reminder(newId, date, noteId);
        reminders.Add(newReminder);
        Console.WriteLine($"Reminder for Note {noteId} added on {date}.");
    }

    
    public void ManageReminder(int reminderId, DateTime newDate)
    {
        Reminder reminderToManage = FindReminderById(reminderId);
        if (reminderToManage != null)
        {
            reminderToManage.EditReminder(newDate);
            Console.WriteLine($"Reminder {reminderId} updated to new date {newDate}.");
        }
        else
        {
            Console.WriteLine($"Reminder with ID {reminderId} not found.");
        }
    }

    
    public void DeleteReminder(int reminderId)
    {
        Reminder reminderToDelete = FindReminderById(reminderId);
        if (reminderToDelete != null)
        {
            reminders.Remove(reminderToDelete);
            Console.WriteLine($"Reminder {reminderId} deleted.");
        }
        else
        {
            Console.WriteLine($"Reminder with ID {reminderId} not found.");
        }
    }

    
    private Reminder FindReminderById(int reminderId)
    {
        return reminders.FirstOrDefault(r => r.Rid == reminderId);
    }

    
    public void SaveReminders()
    {
        using (StreamWriter writer = new StreamWriter("reminders.txt"))
        {
            foreach (var reminder in reminders)
            {
                writer.WriteLine(reminder.ToString());
            }
        }
    }

    
    public void LoadReminders()
    {
        if (File.Exists("reminders.txt"))
        {
            string[] lines = File.ReadAllLines("reminders.txt");
            foreach (var line in lines)
            {
                reminders.Add(Reminder.FromString(line));
            }
        }
    }

    
    public List<Reminder> GetReminders()
    {
        return reminders;
    }
}
