namespace Serilisation;

internal class Program
{
    static void Main(string[] args)
    {
        Trainee trainee = new Trainee
        {
            SpartaNo = 01,
            FirstName = "Connor",
            LastName = "Dawson"
        };

        Course tech205 = new Course
        {
            Title = "Technology 205",
            Subject = "C# Development"
        };
        tech205.AddTrainee(trainee);
        tech205.AddTrainee(
         new Trainee
         {
             SpartaNo = 02,
             FirstName = "Laura",
             LastName = "Tozer"
         });

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        var serialiserXml = new SerialiserXml();
        var serialiserJson = new SerialiserJSON();

        string fullTraineePath = path + "\\Trainee.xml";
        Serialsie(trainee, fullTraineePath, serialiserXml);
        Trainee traineeDeserialisedXml = DeSerialsise<Trainee>(fullTraineePath, serialiserXml);

        string fullCoursePath = path + "\\Course.xml";
        Serialsie(tech205, fullCoursePath, serialiserXml);
        Course courseDeserialisedXml = DeSerialsise<Course>(fullCoursePath, serialiserXml);


        string fullTraineePathJson = path + "\\Trainee.json";
        Serialsie(trainee, fullTraineePathJson, serialiserJson);
        Trainee traineeDeserialisedJson = DeSerialsise<Trainee>(fullTraineePathJson, serialiserJson);

        string fullCoursePathJson = path + "\\Course.json";
        Serialsie(tech205, fullCoursePathJson, serialiserJson);
        Course courseDeserialisedXmlJson = DeSerialsise<Course>(fullCoursePathJson, serialiserJson);

        Console.WriteLine(traineeDeserialisedJson);
        Console.WriteLine(courseDeserialisedXmlJson);
    }

    private static void Serialsie<T>(T objToSerialise, string toPath, ISerialiser serialiser)
    {
        serialiser.Serialise(objToSerialise, toPath);
    }

    private static T DeSerialsise<T>(string fromPath, ISerialiser serialiser)
    {
        return serialiser.Deserialise<T>(fromPath);
    }
}
