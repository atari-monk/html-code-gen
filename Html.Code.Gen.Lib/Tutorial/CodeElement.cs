using System.Text;

namespace Html.Code.Gen.Lib.Serialize;

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
       html.AppendLine($"        <code id='code{Nr}'>");
       html.AppendLine($"            {GetCodeWithMarkedParams()}");
        html.AppendLine("        </code>");
        html.AppendLine("        <br>");
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
