using Newtonsoft.Json;

namespace Serilisation;

public class Trainee
{

    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int? SpartaNo { get; init; }
    [JsonIgnore]
    public string FullName => $"{FirstName} {LastName}";
    public override string ToString()
    {
        return $"{SpartaNo} - {FullName}";
    }

}
