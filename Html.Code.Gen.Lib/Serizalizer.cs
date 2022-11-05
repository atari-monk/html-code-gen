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

public class FilesSerizalizer
    : Serizalizer
{
    private readonly string path = 
        @"C:\atari-monk\Doc\html-code-gen\files.json";
    private readonly Dictionary<string, FileDto> files = new() {{ 
        "docker-compose-voteapp", 
        new FileDto(
            @"C:\atari-monk\Doc\html-code-gen\docker-compose-voteapp.json",
            @"C:\atari-monk\Doc\html-code-gen\docker-compose-voteapp.html")}};

    public void SerializeSchema(){
        Serialize<Dictionary<string, FileDto>>(path, files);
    }
}