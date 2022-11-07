using Html.Code.Gen.Lib;
using Html.Code.Gen.Lib.Serialize;

var root =  @"C:\atari-monk";
var files = new Deserizalizer().Deserialize<FileDto>(root + @"\Doc\html-code-gen\files.json");
Console.WriteLine("Generating html templates...");
var tool = new TutorialData();
var gen = new HtmlGen();
foreach (var file in files)
{
    Console.WriteLine($"File: {file.Key}");
    Console.WriteLine($"Input: {file.Value.JsonPath}");
    ArgumentNullException.ThrowIfNull(file.Value.JsonPath);
    var data = tool.Deserialize(file.Value.JsonPath);
    ArgumentNullException.ThrowIfNull(file.Value.HtmlPath);
    File.WriteAllText(file.Value.HtmlPath, gen.GetHtml(data));
    Console.WriteLine($"Output: {file.Value.HtmlPath}");
}