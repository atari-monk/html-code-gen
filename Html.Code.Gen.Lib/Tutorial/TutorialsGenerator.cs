using Html.Code.Gen.Lib.Serialize;

namespace Html.Code.Gen.Lib;

public class TutorialsGenerator : IHtmlGenerator
{
    public void GenerateHtmlFiles()
    {
        Console.WriteLine("Generating html files...");
        ProcessInputFiles();
    }

    private void ProcessInputFiles()
    {
        foreach (var file in ConvertFiles(GetFiles()))
        {
            PrintFileData(file);
            if (IsThereInputFile(file))
            {
                PrintNoInputFile(file);
                continue;
            }
            CreateOutputFile(file);
        }
    }

    private Dictionary<string, FileDtoRecord> ConvertFiles(Dictionary<string, FileDto> files)
    {
        var data = new Dictionary<string, FileDtoRecord>();
        foreach (var file in files)
        {
            data.Add(file.Key, ConvertFile(file.Value));
        }
        return data;
    }

    private FileDtoRecord ConvertFile(FileDto file)
    {
        ArgumentNullException.ThrowIfNull(file.JsonPath);
        ArgumentNullException.ThrowIfNull(file.HtmlPath);
        return new FileDtoRecord(file.JsonPath, file.HtmlPath);
    }

    private Dictionary<string, FileDto> GetFiles()
    {
        return new Deserizalizer().Deserialize<FileDto>(
            @"C:\atari-monk\Code\apps-data\html-code-gen\files.json");
    }

    private void PrintFileData(KeyValuePair<string, FileDtoRecord> file)
    {
        Console.WriteLine($"File: {file.Key}");
        Console.WriteLine($"Input: {file.Value.JsonPath}");
        Console.WriteLine($"Output: {file.Value.HtmlPath}");
    }

    private bool IsThereInputFile(KeyValuePair<string, FileDtoRecord> file)
    {
        return File.Exists(file.Value.JsonPath) == false;
    }

    private void PrintNoInputFile(KeyValuePair<string, FileDtoRecord> file)
    {
        Console.WriteLine($"Input File: {file.Key} is missing!");
    }

    private void CreateOutputFile(KeyValuePair<string, FileDtoRecord> file)
    {
        File.WriteAllText(
            file.Value.HtmlPath
            , new HtmlGen().GetHtml(
                new TutorialData().Deserialize(
                    file.Value.JsonPath)));
    }
}