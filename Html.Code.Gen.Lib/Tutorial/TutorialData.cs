using System.Text.Json;

namespace Html.Code.Gen.Lib.Serialize;

public class TutorialData{

    public List<TutorialStep> Deserialize(string jsonPath)
    {
        var json = File.ReadAllText(jsonPath);
        var data = JsonSerializer.Deserialize<List<TutorialStep>>(json);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }
} 