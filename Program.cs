public class Program
{
    public static void Main(string[] args)
    {
        NoteManager noteManager = new NoteManager();
        ReminderManager reminderManager = new ReminderManager();

        Console.WriteLine("Welcome to the Notes and Reminders Manager!");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Create a Note");
            Console.WriteLine("2. View All Notes");
            Console.WriteLine("3. Edit a Note");
            Console.WriteLine("4. Delete a Note");
            Console.WriteLine("5. Add a Reminder to a Note");
            Console.WriteLine("6. View All Reminders");
            Console.WriteLine("7. Edit a Reminder");
            Console.WriteLine("8. Delete a Reminder");
            Console.WriteLine("9. Exit");
            Console.Write("Select an option: ");
            
            string option = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(option)) 
            {
                Console.WriteLine("No option selected, please try again.");
                continue;
            }

            Console.WriteLine();

            switch (option)
            {
                case "1":
 
                    Console.Write("Enter Note Title: ");
                    string title = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(title)) continue;
                    
                    Console.Write("Enter Note Content: ");
                    string content = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(content)) continue;
                    
                    Console.Write("Enter Note Position: ");
                    string position = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(position)) continue;

                    noteManager.CreateNote(title, content, position);
                    noteManager.SaveNotes();
                    break;

                case "2":
                  
                    Console.WriteLine("Notes:");
                    foreach (var note in noteManager.GetNotes())
                    {
                        Console.WriteLine(note);
                    }
                    break;

                case "3":
                
                    Console.Write("Enter the ID of the note to edit: ");
                    string noteIdInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(noteIdInput) || !int.TryParse(noteIdInput, out int noteIdToEdit)) 
                    {
                        Console.WriteLine("Invalid Note ID.");
                        continue; 
                    }

                    Console.Write("Enter the new title: ");
                    string newTitle = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newTitle)) continue;

                    Console.Write("Enter the new content: ");
                    string newContent = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newContent)) continue; 

                    Console.Write("Enter the new position (lower number = higher priority): ");
                    string newPosition = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newPosition)) continue; 

                    noteManager.EditNote(noteIdToEdit, newTitle, newContent, newPosition); 
                    break;


                case "4":
                    
                    Console.Write("Enter Note ID to Delete: ");
                    string deleteNoteIdInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(deleteNoteIdInput) || !int.TryParse(deleteNoteIdInput, out int noteIdToDelete))
                    {
                        Console.WriteLine("Invalid Note ID.");
                        continue;
                    }

                    noteManager.DeleteNote(noteIdToDelete);
                    noteManager.SaveNotes();
                    break;

                case "5":
                   
                    Console.Write("Enter Note ID to Add Reminder: ");
                    string noteForReminderInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(noteForReminderInput) || !int.TryParse(noteForReminderInput, out int noteIdForReminder))
                    {
                        Console.WriteLine("Invalid Note ID.");
                        continue;
                    }

                    Console.Write("Enter Reminder Date and Time (yyyy-MM-dd HH:mm): ");
                    string reminderDateInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(reminderDateInput) || !DateTime.TryParse(reminderDateInput, out DateTime reminderDate))
                    {
                        Console.WriteLine("Invalid Date and Time format.");
                        continue;
                    }

                    reminderManager.AddReminder(noteIdForReminder, reminderDate);
                    reminderManager.SaveReminders();
                    break;

                case "6":
                   
                    Console.WriteLine("Reminders:");
                    foreach (var reminder in reminderManager.GetReminders())
                    {
                        Console.WriteLine(reminder);
                    }
                    break;

                case "7":
                    
                    Console.Write("Enter Reminder ID to Edit: ");
                    string reminderIdInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(reminderIdInput) || !int.TryParse(reminderIdInput, out int reminderIdToEdit))
                    {
                        Console.WriteLine("Invalid Reminder ID.");
                        continue;
                    }

                    Console.Write("Enter New Reminder Date and Time (yyyy-MM-dd HH:mm): ");
                    string newReminderDateInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newReminderDateInput) || !DateTime.TryParse(newReminderDateInput, out DateTime newReminderDate))
                    {
                        Console.WriteLine("Invalid Date and Time format.");
                        continue;
                    }

                    reminderManager.ManageReminder(reminderIdToEdit, newReminderDate);
                    reminderManager.SaveReminders();
                    break;

                case "8":
                    
                    Console.Write("Enter Reminder ID to Delete: ");
                    string deleteReminderIdInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(deleteReminderIdInput) || !int.TryParse(deleteReminderIdInput, out int reminderIdToDelete))
                    {
                        Console.WriteLine("Invalid Reminder ID.");
                        continue;
                    }

                    reminderManager.DeleteReminder(reminderIdToDelete);
                    reminderManager.SaveReminders();
                    break;

                case "9":
                    
                    Console.WriteLine("Saving all data...");
                    noteManager.SaveNotes();
                    reminderManager.SaveReminders();
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
