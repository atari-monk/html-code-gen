using System.Text.Json;

namespace Html.Code.Gen.Lib.Serialize;

public class TestSerizalize
{
    public void GetJsonFromTestData()
    {
        var fileName = @"C:\atari-monk\Doc\jsonFromTestData.json";
        var data = new TutorialStep() { 
            Title = "Create resource group"
            , Codes = new CodeElement[] { 
                new CodeElement{ 
                    Nr = 1
                    , CodeFormat = "az group create --name {0} --location {1}"
                    , CodeParams = new CodeParam[] { 
                        new CodeParam { Name = "CommonResourceGroup"
                            , Desc = "Choose your ResourceGroup name"
                            , CssClass = "mark-resource-group"}}} }};
        var jsonString = JsonSerializer.Serialize(data);
        File.WriteAllText(fileName, jsonString);
        var json = File.ReadAllText(fileName);
        TutorialStep? deserializedData =
            JsonSerializer.Deserialize<TutorialStep>(json);
    }

    public void GetJsonFromTestList()
    {
        var fileName = @"C:\atari-monk\Doc\jsonFromTestList.json";
        var step1 = new TutorialStep() { 
            Title = "Create resource group"
            , Codes = new CodeElement[] { 
                new CodeElement{ 
                    Nr = 1
                    , CodeFormat = "az group create --name {0} --location {1}"
                    , CodeParams = new CodeParam[] { 
                        new CodeParam { Name = "CommonResourceGroup"
                            , Desc = "Choose your ResourceGroup name"
                            , CssClass = "mark-resource-group"}}} }};
        var list = new List<TutorialStep> { step1, step1 };
        var jsonString = JsonSerializer.Serialize(list);
        File.WriteAllText(fileName, jsonString);
        var json = File.ReadAllText(fileName);
        List<TutorialStep>? deserializedList =
            JsonSerializer.Deserialize<List<TutorialStep>>(json);
    }
}
