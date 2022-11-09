using System.Text;

namespace Html.Code.Gen.Lib.Serialize;

public class TutorialStep
{
    public string? Title { get; set; }
    public CodeElement[]? Codes { get; set; }
    
    public string GetStepHtml()
    {   
        var isAsideNeeded = IsAsideNeeded();
        var html = new StringBuilder();
        html.AppendLine("<li>");
        html.AppendLine("    <p>");
        html.AppendLine($"        {Title}");
        html.AppendLine("    </p>");
        if (isAsideNeeded)
        {
            html.AppendLine("    <aside>");
            html.AppendLine("        <details>");
            html.AppendLine("            <summary>details</summary>");
            if (Codes != null)
                foreach (var code in Codes)
                {
                    html.Append(code.GetParamDescs());
                }
            html.AppendLine("        </details>");
            html.AppendLine("    </aside>");
        }
        html.AppendLine("    <p>");
        if (Codes != null)
            foreach (var code in Codes)
            {
                html.AppendLine($"        <button onclick=\"Copy('code{code.Nr}')\">Copy</button>");
                html.Append(code.GetCodeHtml());
            }
        html.AppendLine("    </p>");
        html.AppendLine("</li>");
        return html.ToString();
    }

    private bool IsAsideNeeded()
    {
        var result = false;
        if (Codes != null && Codes.Length > 0)
        {
            foreach (var code in Codes)
            {
                if (code.CodeParams != null && code.CodeParams.Length > 0)
                {
                    result = true;
                    break;
                }
            }
        }
        return result;
    }
}