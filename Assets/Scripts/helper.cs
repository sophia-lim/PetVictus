using System.IO;
using System.Xml.Serialization;

public static class helper {

    // Helps with Serializing and deserializing classes.

    // Serialize: Writes information to phone
    public static string Serialize<T>(this T toSerialize) {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSerialize);
        return writer.ToString();
    }

    // Deserialize: Reads information from phone
    public static T Deserialize<T>(this string toDeserialize) {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringReader reader = new StringReader(toDeserialize);
        return (T)xml.Deserialize(reader);

    }

}
