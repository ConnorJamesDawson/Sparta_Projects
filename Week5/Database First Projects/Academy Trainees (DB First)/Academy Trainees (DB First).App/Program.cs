using Academy_Trainees__DB_First_.App.Models;
using Academy_Trainees__DB_First_.App.Models.Trainee_Database_Interactions;
using Academy_Trainees__DB_First_.App.Models.Trainee_Database_Interactions.Queries;
using System.Security.Cryptography;

namespace Academy_Trainees__DB_First_.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AcademyContext())
            {
                GeneralDatabaseInteractions_Trainee.DemoDatabaseMethods(db);
                QueryForName.QueryForNameBeginningWithChar(db, 'C');
            }
        }
    }
}