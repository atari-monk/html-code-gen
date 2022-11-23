using Html.Code.Gen.Lib;

IHtmlGenerator generator = new TutorialsGenerator();
generator.GenerateHtmlFiles();

// var filesScheme = new FilesSerizalizer();
// filesScheme.SerializeSchema();

// var dataJson = new TutorialSerizalizer();
// dataJson.GetJsonFromTestList();

// IHtmlGeneratorAsync generator = new TableGenerator(@"C:\atari-monk\Code\sql\Task1\person.txt");
// await generator.GenerateHtmlFilesAsync();
// IHtmlGeneratorAsync generator = new TableGenerator(@"C:\atari-monk\Code\sql\Task1\address.txt");
// await generator.GenerateHtmlFilesAsync();
// IHtmlGeneratorAsync generator = new TableGenerator(@"C:\atari-monk\Code\sql\Task1\address-type.txt");
// await generator.GenerateHtmlFilesAsync();

// IHtmlGeneratorAsync generator = new InsertGenerator(@"C:\atari-monk\Code\sql\Task1\person.txt", 4);
// await generator.GenerateHtmlFilesAsync();
// IHtmlGeneratorAsync generator = new InsertGenerator(@"C:\atari-monk\Code\sql\Task1\address.txt", 5);
// await generator.GenerateHtmlFilesAsync();