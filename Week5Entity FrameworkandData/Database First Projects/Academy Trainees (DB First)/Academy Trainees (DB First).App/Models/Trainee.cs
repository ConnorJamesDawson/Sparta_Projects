using System;
using System.Collections.Generic;

namespace Academy_Trainees__DB_First_.App.Models;

public partial class Trainee
{
    public int TraineeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Course { get; set; }

    public string? Location { get; set; }
}
