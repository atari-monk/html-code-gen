using System.Text;
using System.Text.Json;

namespace Html.Code.Gen.Lib.Serialize;

public class TutorialStep
{
    public string? Title { get; set; }
    public CodeElement[]? Codes { get; set; }

    public string GetStepHtml()
    {
        var html = new StringBuilder();
        html.AppendLine("                    <li>");
        html.AppendLine("                       <p>");
        html.AppendLine($"                           {Title}");
        html.AppendLine("                       </p>");
        html.AppendLine("                       <aside>");
        html.AppendLine("                            <details>");
        html.AppendLine("                                <summary>details</summary>");
        if(Codes != null)
        foreach (var code in Codes)
        {
            html.Append(code.GetParamDescs());
        }
        html.AppendLine("                            </details>");
        html.AppendLine("                        </aside>");
        html.AppendLine("                        <p>");
        if(Codes != null)
        foreach (var code in Codes)
        {
            html.AppendLine($"                           <button onclick=\"Copy('code{code.Nr}')\">Copy</button>");
            html.Append(code.GetCodeHtml());
        }
        html.AppendLine("                        </p>");
        html.AppendLine("                    </li>");
        return html.ToString();
    }
}

public class CodeElement
{
    public int Nr { get; set; }
    public string? CodeFormat { get; set; }
    public CodeParam[]? CodeParams { get; set; }

    public string GetParamDescs()
    {
        var sb = new StringBuilder();
        if(CodeParams != null)
            foreach (var param in CodeParams)
            {
                sb.AppendLine(param.GetParamDescHtml());
            }
        return sb.ToString();
    }

    public string GetCodeHtml()
    {
        var html = new StringBuilder();
       html.AppendLine($"                           <code id='code{Nr}'>");
       html.AppendLine($"                               {GetCodeWithMarkedParams()}");
        html.AppendLine("                           </code>");
        return html.ToString();
    }

    private string GetCodeWithMarkedParams()
    {
        if(CodeParams != null && string.IsNullOrWhiteSpace(CodeFormat) == false)
        {
            var names = new List<string>();
            foreach (var param in CodeParams)
            {
                names.Add(param.GetMarkedNameHtml());
            } 
            return string.Format(CodeFormat, names.ToArray());
        }
        return CodeFormat ?? "";
    }
}

public class CodeParam
{
    public string? Name { get; set; }
    public string? Desc { get; set; }
    public string? CssClass { get; set; }

    public string GetParamDescHtml()
    {
        return $"                                <p><mark class=\"{CssClass}\">{Desc}</mark></p>";
    }

    public string GetMarkedNameHtml()
    {
        return $"<mark class=\"{CssClass}\">{Name}</mark>";
    }
}

// new TutorialStepWithParams("Create resource group"
//     , new CodeWithParams[] { new CodeWithParams(1, "az group create --name {0} --location {1}"
//     , new CodeParam[] {
//         new CodeParam("CommonResourceGroup", "Choose your ResourceGroup name", "mark-resource-group")
//         , new CodeParam("swedencentral", "Choose your Location name", "mark-location")
//     })})

public class TestSerizalize
{
    public void Test()
    {
        var tutStep = new TutorialStep() { 
            Title = "Create resource group"
            , Codes = new CodeElement[] { 
                new CodeElement{ 
                    Nr = 1
                    , CodeFormat = "az group create --name {0} --location {1}"
                    , CodeParams = new CodeParam[] { 
                        new CodeParam { Name = "CommonResourceGroup"
                            , Desc = "Choose your ResourceGroup name"
                            , CssClass = "mark-resource-group"}}} }};
        string jsonString = JsonSerializer.Serialize(tutStep);
        //Console.WriteLine(jsonString);
        string fileName = @"C:\atari-monk\Doc\serializationTest.json";
        File.WriteAllText(fileName, jsonString);
        var json2 = File.ReadAllText(fileName);
        TutorialStep? tutStep2 =
            JsonSerializer.Deserialize<TutorialStep>(json2);
    }

    public void Test2()
    {
        var tutStep1 = new TutorialStep() { 
            Title = "Create resource group"
            , Codes = new CodeElement[] { 
                new CodeElement{ 
                    Nr = 1
                    , CodeFormat = "az group create --name {0} --location {1}"
                    , CodeParams = new CodeParam[] { 
                        new CodeParam { Name = "CommonResourceGroup"
                            , Desc = "Choose your ResourceGroup name"
                            , CssClass = "mark-resource-group"}}} }};
        var tutStep2 = new TutorialStep() { 
            Title = "Create resource group"
            , Codes = new CodeElement[] { 
                new CodeElement{ 
                    Nr = 1
                    , CodeFormat = "az group create --name {0} --location {1}"
                    , CodeParams = new CodeParam[] { 
                        new CodeParam { Name = "CommonResourceGroup"
                            , Desc = "Choose your ResourceGroup name"
                            , CssClass = "mark-resource-group"}}} }};
        var list = new List<TutorialStep>();
        list.Add(tutStep1);
        list.Add(tutStep2);
        string jsonString = JsonSerializer.Serialize(list);
        //Console.WriteLine(jsonString);
        string fileName = @"C:\atari-monk\Doc\serializationTestList.json";
        File.WriteAllText(fileName, jsonString);
        var json2 = File.ReadAllText(fileName);
        List<TutorialStep>? list2 =
            JsonSerializer.Deserialize<List<TutorialStep>>(json2);
    }
}

public class TutorialData{

    public List<TutorialStep> Deserialize(string jsonPath)
    {
        var json = File.ReadAllText(jsonPath);
        var data = JsonSerializer.Deserialize<List<TutorialStep>>(json);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }
} 