using System.Text.Json;

namespace Html.Code.Gen.Lib.Serialize;

public class Serizalizer
{
    public void Serialize<TData>(string filePath, TData data)
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(data));
    }

    public void Serialize<TData>(string filePath, Dictionary<string, TData> data)
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(data));
    }
}