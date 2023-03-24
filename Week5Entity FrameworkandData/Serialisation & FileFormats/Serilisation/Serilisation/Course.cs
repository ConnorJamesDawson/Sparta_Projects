namespace Serilisation;

public  class Course
{
    public string? Title { get; set; }
    public string? Subject { get; set; }
    public List<Trainee> Trainees { get; } = new List<Trainee>(); public void AddTrainee(Trainee trainee)
    {
        Trainees.Add(trainee);
    }

}
