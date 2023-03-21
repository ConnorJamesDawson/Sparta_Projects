namespace Academy_Trainees__DB_First_.App.Models.Trainee_Database_Interactions.Queries;

public static class QueryForName
{

    public static Trainee[] QueryForNameBeginningWithChar(AcademyContext db, char charLookingFor)
    {
        Console.WriteLine();
        Trainee[] traineeArray = db.Trainees.ToArray();

        IEnumerable<Trainee> traineeQuery = //This structures the iterator so it follows the where clause
            from trainee in traineeArray
            where trainee.Name.First() == charLookingFor
            orderby trainee.Name
            select trainee;

        foreach (Trainee trainee in traineeQuery)
        {
            Console.WriteLine($"{trainee.Name}, {trainee.TraineeId}");
        }
        return traineeArray;
    }

}
