using SpartaToDo.App.Models;

namespace SpartaToDo.App.Data;

public class SeedData
{

    public static void Initialise(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<SpartaToDoContext>();

        if (context.ToDoItems.Any())
        {
            context.ToDoItems.RemoveRange(context.ToDoItems);
            context.SaveChanges();
        }

        context.ToDoItems.AddRange(
        new ToDo
        {
            Title = "Complete survey",
            Description = "Complete the weekly survey",
            Complete = false,
            DateCreated = new DateTime(2023, 01, 03)
        },
        new ToDo
        {
            Title = "Timecards",
            Description = "Complete timecard for this week",
            Complete = true,
            DateCreated = new DateTime(2023, 01, 05)
        },
        new ToDo
        {
            Title = "Friday stand-up",
            Description = "Do the academy stand-up on Friday",
            Complete = false,
            DateCreated = new DateTime(2023, 01, 03)
        }
        );
        context.SaveChanges();
    }

}
