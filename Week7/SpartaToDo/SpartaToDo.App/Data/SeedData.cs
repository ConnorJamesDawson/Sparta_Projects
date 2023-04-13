using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SpartaToDo.App.Data;
using SpartaToDo.App.Models;

public class SeedData
{
    public static void Initialise(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<SpartaToDoContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<Spartan>>();
        var roleStore = new RoleStore<IdentityRole>(context);



        if (context.Spartans.Any())
        {
            context.Spartans.RemoveRange(context.Spartans);
            context.UserRoles.RemoveRange(context.UserRoles);
            context.Roles.RemoveRange(context.Roles);
            context.SaveChanges();
        }



        var trainer = new IdentityRole
        {
            Name = "Trainer",
            NormalizedName = "TRAINER"
        };
        var trainee = new IdentityRole
        {
            Name = "Trainee",
            NormalizedName = "TRAINEE"
        };



        roleStore
        .CreateAsync(trainer)
        .GetAwaiter()
        .GetResult();
        roleStore
        .CreateAsync(trainee)
        .GetAwaiter()
        .GetResult();



        var phil = new Spartan
        {
            UserName = "phil@spartaglobal.com",
            Email = "phil@spartaglobal.com",
            EmailConfirmed = true
        };
        var laura = new Spartan
        {
            UserName = "laura@spartaglobal.com",
            Email = "laura@spartaglobal.com",
            EmailConfirmed = true,
        };
        var cathy = new Spartan
        {
            UserName = "cathy@spartaglobal.com",
            Email = "cathy@spartaglobal.com",
            EmailConfirmed = true,
        };



        userManager
        .CreateAsync(phil, "Password1!")
        .GetAwaiter()
        .GetResult();
        userManager
        .CreateAsync(laura, "Password1!")
        .GetAwaiter()
        .GetResult();
        userManager
        .CreateAsync(cathy, "Password1!")
        .GetAwaiter()
        .GetResult();



        context.UserRoles.AddRange(new IdentityUserRole<string>[]
        {
             new IdentityUserRole<string>
             {
                 UserId = userManager.GetUserIdAsync(phil).Result,
                 RoleId = roleStore.GetRoleIdAsync(trainee).Result
             },
             new IdentityUserRole<string>
             {
                 UserId = userManager.GetUserIdAsync(laura).Result,
                 RoleId = roleStore.GetRoleIdAsync(trainee).Result
             },
             new IdentityUserRole<string>
             {
                 UserId = userManager.GetUserIdAsync(cathy).Result,
                 RoleId = roleStore.GetRoleIdAsync(trainer).Result
             }
        });



        context.ToDoItems.AddRange(
        new ToDo
        {
            Title = "Complete survey",
            Description = "Complete the weekly survey",
            Complete = false,
            DateCreated = new DateTime(2023, 01, 03),
            Spartan = phil
        },
        new ToDo
        {
            Title = "Timecards",
            Description = "Complete timecard for this week",
            Complete = true,
            DateCreated = new DateTime(2023, 01, 05),
            Spartan = phil
        },
        new ToDo
        {
            Title = "Friday stand-up",
            Description = "Do the academy stand-up on Friday",
            Complete = false,
            DateCreated = new DateTime(2023, 01, 03),
            Spartan = laura
        },
        new ToDo
        {
            Title = "Trainee Tracker",
            Description = "Complete start, stop, continue for this week",
            Complete = false,
            DateCreated = new DateTime(2023, 01, 05),
            Spartan = laura
        },
        new ToDo
        {
            Title = "Create Repo",
            Description = "Create repository on GitHub for this week",
            Complete = true,
            DateCreated = new DateTime(2023, 01, 02),
            Spartan = phil
        }
        );
        context.SaveChanges();
    }
}