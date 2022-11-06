using System.Net.Http.Headers;
using Html.Code.Gen.Lib;
using Html.Code.Gen.Lib.Serialize;

var root =  @"C:\atari-monk";
// var jsonPath = @"C:\atari-monk\Doc\docker-compose-voteapp.json";
// var htmlPath = @"C:\atari-monk\Doc\docker-compose-voteapp.html";
// Console.WriteLine("Generating html templates...");
// Console.WriteLine($"Input: {jsonPath}");
// Console.WriteLine($"Output: {htmlPath}");
// var tool = new TutorialData();
// var data = tool.Deserialize(jsonPath);
// var gen = new HtmlGen();
// var text = gen.GetHtml(data);
// File.WriteAllText(htmlPath, text);

var filesSchema = new FilesSerizalizer();
filesSchema.SerializeSchema();

var files = new Deserizalizer().Deserialize<FileDto>(root + @"\Doc\html-code-gen\files.json");

//var files = new Deserizalizer().DeserializeList<FileDto>(root + @"\Doc\html-code-gen\files.json");
Console.WriteLine(files);