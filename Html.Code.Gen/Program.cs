using Html.Code.Gen.Lib;
using Html.Code.Gen.Lib.Serialize;

var root =  @"C:\atari-monk";
var files = new Deserizalizer().Deserialize<FileDto>(root + @"\Doc\html-code-gen\files.json");
Console.WriteLine("Generating html templates...");
var tool = new TutorialData();
var gen = new HtmlGen();
var fileNames = new string[] { 
    "deploy-voting-app", "aci-sql-server", "cpp-compiler" 
    };
var select = fileNames[1];
foreach (var file in files)
{
    if(file.Key != select) continue;
    Console.WriteLine($"File: {file.Key}");
    Console.WriteLine($"Input: {file.Value.JsonPath}");
    ArgumentNullException.ThrowIfNull(file.Value.JsonPath);
    var data = tool.Deserialize(file.Value.JsonPath);
    ArgumentNullException.ThrowIfNull(file.Value.HtmlPath);
    File.WriteAllText(file.Value.HtmlPath, gen.GetHtml(data));
    Console.WriteLine($"Output: {file.Value.HtmlPath}");
}