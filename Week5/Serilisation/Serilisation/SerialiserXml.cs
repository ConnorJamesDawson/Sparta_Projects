using System.Xml.Serialization;

namespace Serilisation;

internal class SerialiserXml : ISerialiser
{
    public void Serialise<T>(T item, string toPath)
    {
        FileStream fileStream = File.Create(toPath);

        XmlSerializer writer = new XmlSerializer(typeof(T));

        writer.Serialize(fileStream, item);

        fileStream.Close();
    }


    public T Deserialise<T>(string fromPath)
    {
        Stream fileStream = File.OpenRead(fromPath);
        XmlSerializer reader = new XmlSerializer(typeof(T));

        var deserialisedItem = (T)reader.Deserialize(fileStream)!;
        fileStream.Close();

        return deserialisedItem!;
    }
}
