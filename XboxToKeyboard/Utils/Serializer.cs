using Newtonsoft.Json;
using System.IO;

namespace XboxToKeyboard.Utils;

public static class Serializer
{
    private readonly static string _path = "Config.json";

    public static void SerializeToFile(this GamePadBinding gamePadBinding)
    {
        string json = JsonConvert.SerializeObject(gamePadBinding, Formatting.Indented);
        File.WriteAllText(_path, json);
    }

    public static GamePadBinding DeserializeFromFile()
    {
        try
        {
            if (!File.Exists(_path))
            {
                return null;
            }

            string json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<GamePadBinding>(json);
        }
        catch (Exception)
        {
            return null;
        }
    }
}
