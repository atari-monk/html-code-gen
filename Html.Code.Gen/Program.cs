﻿using Html.Code.Gen.Lib;
using Html.Code.Gen.Lib.Serialize;

var root = @"C:\atari-monk\Code\apps-data\html-code-gen\";
var files = new Deserizalizer().Deserialize<FileDto>(root + "files.json");
Console.WriteLine("Generating html templates...");
var tool = new TutorialData();
var gen = new HtmlGen();
var fileNames = new string[] {
    "azure-sql-db", "cpp-compiler", "local-nugets",
    "new-github-repo", "schema", "secrets",
    "ssms-azure", "todo-app-azure", "voting-app-azure",
    "web-app-dotnet-upgrade"
    };
//var select = fileNames[2];
foreach (var file in files)
{
    //if(file.Key != select) continue;
    Console.WriteLine($"File: {file.Key}");
    Console.WriteLine($"Input: {file.Value.JsonPath}");
    ArgumentNullException.ThrowIfNull(file.Value.JsonPath);
    if (File.Exists(file.Value.JsonPath) == false) continue;
    var data = tool.Deserialize(file.Value.JsonPath);
    ArgumentNullException.ThrowIfNull(file.Value.HtmlPath);
    File.WriteAllText(file.Value.HtmlPath, gen.GetHtml(data));
    Console.WriteLine($"Output: {file.Value.HtmlPath}");
}

// var filesScheme = new FilesSerizalizer();
// filesScheme.SerializeSchema();

// var dataJson = new TutorialSerizalizer();
// dataJson.GetJsonFromTestList();