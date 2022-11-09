using System.Text.Json;

namespace Html.Code.Gen.Lib.Serialize;

public class TutorialSerizalizer
{
    private readonly string root;

    public TutorialSerizalizer()
    {
        root = @"C:\atari-monk\apps-data\html-code-gen\";
    }

    public void GetJsonFromTestData()
    {
        var fileName = root + "jsonFromTestData.json";
        var data = new TutorialStep() { 
            Title = "test"
            , Codes = new CodeElement[] { 
                new CodeElement{ 
                    Nr = 1
                    , CodeFormat = "test"
                    , CodeParams = new CodeParam[] { 
                        new CodeParam { Name = "test"
                            , Desc = "test"
                            , CssClass = "test"}}} }};
        var jsonString = JsonSerializer.Serialize(data);
        File.WriteAllText(fileName, jsonString);
        var json = File.ReadAllText(fileName);
        TutorialStep? deserializedData =
            JsonSerializer.Deserialize<TutorialStep>(json);
    }

    public void GetJsonFromTestList()
    {
        var fileName = root + "jsonFromTestList.json";
        var step1 = new TutorialStep() { 
            Title = ""
            , Codes = new CodeElement[] { 
                new CodeElement{ 
                    Nr = 1
                    , CodeFormat = ""
                    , CodeParams = new CodeParam[] { 
                        new CodeParam { Name = ""
                            , Desc = ""
                            , CssClass = ""}}} }};
        var list = new List<TutorialStep> { step1, step1 };
        var jsonString = JsonSerializer.Serialize(list);
        File.WriteAllText(fileName, jsonString);
        var json = File.ReadAllText(fileName);
        List<TutorialStep>? deserializedList =
            JsonSerializer.Deserialize<List<TutorialStep>>(json);
    }
}
