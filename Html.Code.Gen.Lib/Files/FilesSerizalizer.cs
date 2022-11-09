namespace Html.Code.Gen.Lib.Serialize;

public class FilesSerizalizer
    : Serizalizer
{
    private readonly string root = @"C:\atari-monk\Apps.Data\html-code-gen\";
    private readonly string key = "deploy-voting-app";
    private readonly string path;
    private readonly Dictionary<string, FileDto> files;

    public FilesSerizalizer()
    {
        path = Path.Combine(root,"files.json");
        files = new() {{ 
        key, 
        new FileDto {
            JsonPath = Path.Combine(root, "In", key + ".json"),
            HtmlPath = Path.Combine(root, "Out", key + ".html")
        }}};
    }

    public void SerializeSchema(){
        Serialize<Dictionary<string, FileDto>>(path, files);
    }
}