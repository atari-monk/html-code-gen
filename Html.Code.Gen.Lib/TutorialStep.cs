using System.Text;

namespace Html.Code.Gen.Lib;

public interface ITutorialStepWithParams
{
    string GetStepHtml();
}

public class TutorialStepWithParams : ITutorialStepWithParams
{
    public string Title { get; init; }
    public CodeWithParams[] Codes { get; init; }

    public TutorialStepWithParams(string title, CodeWithParams[] codes)
    {
        Title = title;
        Codes = codes;
    }

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
        foreach (var code in Codes)
        {
            html.Append(code.GetParamDescs());
        }
        html.AppendLine("                            </details>");
        html.AppendLine("                        </aside>");
        html.AppendLine("                        <p>");
        foreach (var code in Codes)
        {
            html.AppendLine($"                           <button onclick=\"Copy('code{code.CodeNr}')\">Copy</button>");
            html.Append(code.GetCodeHtml());
        }
        html.AppendLine("                        </p>");
        html.AppendLine("                    </li>");
        return html.ToString();
    }
}

public class CodeWithParams
{
    private readonly string codeFormat;
    private readonly CodeParam[] codeParams;

    public int CodeNr { get; init; }

    public CodeWithParams(
        int codeNr
        , string codeFormat 
        , CodeParam[] codeParams)
    {
        CodeNr = codeNr;
        this.codeFormat = codeFormat;
        this.codeParams = codeParams;
    }

    public string GetCodeHtml()
    {
        var html = new StringBuilder();
       html.AppendLine($"                           <code id='code{CodeNr}'>");
       html.AppendLine($"                               {GetCodeWithMarkedParams()}");
        html.AppendLine("                           </code>");
        return html.ToString();
    }

    private string GetCodeWithMarkedParams()
    {
        var names = new List<string>();
        foreach (var param in codeParams)
        {
            names.Add(param.GetMarkedNameHtml());
        } 
        return string.Format(codeFormat, names.ToArray());
    }

    public string GetParamDescs()
    {
        var sb = new StringBuilder();
        foreach (var param in codeParams)
        {
            sb.AppendLine(param.GetParamDescHtml());
        }
        return sb.ToString();
    }
}

public record CodeParam(string Name, string Desc, string CssClass)
{
    public string GetParamDescHtml()
    {
        return $"                                <p><mark class=\"{CssClass}\">{Desc}</mark></p>";
    }

    public string GetMarkedNameHtml()
    {
        return $"<mark class=\"{CssClass}\">{Name}</mark>";
    }
}

public class CodeWithNoParams
{
    private readonly string code;

    public int CodeNr { get; init; }

    public CodeWithNoParams(
        int codeNr
        , string code)
    {
        CodeNr = codeNr;
        this.code = code;
    }

    public string GetCodeHtml()
    {
        var html = new StringBuilder();
       html.AppendLine($"                           <code id='code{CodeNr}'>");
       html.AppendLine($"                               {code}");
        html.AppendLine("                           </code>");
        return html.ToString();
    }
}

public class TutorialStepWithNoParams : ITutorialStepWithParams
{
    public string Title { get; init; }
    public CodeWithNoParams[] Codes { get; init; }

    public TutorialStepWithNoParams(string title, CodeWithNoParams[] codes)
    {
        Title = title;
        Codes = codes;
    }

    public string GetStepHtml()
    {
        var html = new StringBuilder();
        html.AppendLine("                    <li>");
        html.AppendLine("                       <p>");
       html.AppendLine($"                           {Title}");
        html.AppendLine("                       </p>");
        html.AppendLine("                        <p>");
        foreach (var code in Codes)
        {
       html.AppendLine($"                           <button onclick=\"Copy('code{code.CodeNr}')\">Copy</button>");
        html.Append(code.GetCodeHtml());
        }
        html.AppendLine("                        </p>");
        html.AppendLine("                    </li>");
        return html.ToString();
    }
}