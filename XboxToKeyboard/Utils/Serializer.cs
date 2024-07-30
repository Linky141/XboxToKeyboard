using Newtonsoft.Json;
using System.IO;

namespace XboxToKeyboard.Utils;

public static class Serializer
{
    public static void SerializeToFile<T>(this T value, string path)
    {
        string json = JsonConvert.SerializeObject(value, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public static T? DeserializeFromFile<T>(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                return default;
            }

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception)
        {
            return default;
        }
    }
}
