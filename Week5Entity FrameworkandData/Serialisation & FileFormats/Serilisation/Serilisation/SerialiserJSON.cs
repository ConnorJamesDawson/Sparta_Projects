using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Serilisation;

public class SerialiserJSON : ISerialiser
{

    public void Serialise<T>(T item, string toPath)
    {
        string jsonString = JsonConvert.SerializeObject(item, Formatting.Indented);

        File.WriteAllText(toPath, jsonString);
    }


    public T Deserialise<T>(string fromPath)
    {
        string jsonString = File.ReadAllText(fromPath);

        return JsonConvert.DeserializeObject<T>(jsonString);
    }
}
