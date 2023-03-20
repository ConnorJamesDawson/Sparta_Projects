namespace Academy_Trainees__DB_First_.App.Models.Trainee_Database_Interactions.Queries;

public static class QueryForName
{

    public static void QueryForNameBeginningWithChar(AcademyContext db, char charLookingFor)
    {
        Trainee[] traineeArray = db.Trainees.ToArray();

        IEnumerable<Trainee> traineeQuery =
            from trainee in traineeArray
            where trainee.Name.First() == charLookingFor
            select trainee;

        foreach (Trainee trainee in traineeQuery)
        {
            Console.WriteLine($"{trainee.Name}, {trainee.TraineeId}");
        }
    }

}
