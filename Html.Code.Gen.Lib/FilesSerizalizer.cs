namespace Html.Code.Gen.Lib.Serialize;

public class FilesSerizalizer
    : Serizalizer
{
    private readonly string path = 
        @"C:\atari-monk\Doc\html-code-gen\files.json";
    private readonly Dictionary<string, FileDto> files = new() {{ 
        "docker-compose-voteapp", 
        new FileDto {
            JsonPath = @"C:\atari-monk\Doc\html-code-gen\docker-compose-voteapp.json",
            HtmlPath = @"C:\atari-monk\Doc\html-code-gen\docker-compose-voteapp.html"
        }}};

    public void SerializeSchema(){
        Serialize<Dictionary<string, FileDto>>(path, files);
    }
}

public class FilesSerizalizer2
    : Serizalizer
{
    private readonly string path = 
        @"C:\atari-monk\Doc\html-code-gen\files.json";
    private readonly List<FileDto> files = new() {
        new FileDto {
            JsonPath = @"C:\atari-monk\Doc\html-code-gen\docker-compose-voteapp.json",
            HtmlPath = @"C:\atari-monk\Doc\html-code-gen\docker-compose-voteapp.html"
        }};

    public void SerializeSchema(){
        Serialize<List<FileDto>>(path, files);
    }
}