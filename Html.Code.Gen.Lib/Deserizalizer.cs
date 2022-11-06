using System.Text.Json;

namespace Html.Code.Gen.Lib.Serialize;

public class Deserizalizer
{
    public Dictionary<string, TData> Deserialize<TData>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<Dictionary<string, TData>>(json);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    public List<TData> DeserializeList<TData>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<List<TData>>(json);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }
}