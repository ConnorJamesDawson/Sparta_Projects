namespace Academy_Trainees__DB_First_.App.Models.Trainee_Database_Interactions;

public static class GeneralDatabaseInteractions_Trainee
{
    public static void PrintAllTrainees(AcademyContext db)
    {
        foreach (var trainees in db.Trainees)
        {
            Console.WriteLine(trainees);
        }
    }

    public static void AddTraineeToDatabase(AcademyContext db, int traineeId, string traineeName, string traineeCourse = null, string traineeLocation = null)
    {
        Trainee trainee = new Trainee()
        {
            TraineeId = traineeId,
            Name = traineeName,
            Course = traineeCourse,
            Location = traineeLocation,
        };
        db.Trainees.Add(trainee);
        db.SaveChanges();
    }

    public static void UpdateTraineeInDatabase(AcademyContext db, int traineeId, string traineeName = null, string traineeCourse = null, string traineeLocation = null)
    {
        Trainee selecetedTrainee = db.Trainees.Find(traineeId)!;

        if (traineeName != null) selecetedTrainee.Name = traineeName;

        if (traineeCourse != null) selecetedTrainee.Course = traineeCourse;

        if (traineeLocation != null) selecetedTrainee.Location = traineeLocation;

        db.SaveChanges();
    }

    public static void RemoveTrainee(AcademyContext db, int traineeId)
    {
        db.Trainees.Remove(db.Trainees.Find(traineeId)!);
        db.SaveChanges();
    }
    public static void DemoDatabaseMethods(AcademyContext db) ///Add, Update and Remove said trainee from the database
    {
        PrintAllTrainees(db);
        Console.WriteLine(" --- Add Trainee ");
        AddTraineeToDatabase(db, 3, "Ralf Wigham", "Tech -205", "Springfield");
        PrintAllTrainees(db);
        Console.WriteLine(" --- Update Trainee ");
        UpdateTraineeInDatabase(db, 3, traineeCourse: "Simpsons");
        PrintAllTrainees(db);
        Console.WriteLine(" --- Remove Trainee ");
        RemoveTrainee(db, 3);
        PrintAllTrainees(db);
    }
}
