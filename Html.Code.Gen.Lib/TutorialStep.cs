using System.Text;

namespace Html.Code.Gen.Lib;

public class TutorialStep
{
    public int Nr { get; init; }
    public string Title { get; init; }
    public CodeText CodeText { get; init; }

    public TutorialStep(int nr, string title, CodeText code)
    {
        Nr = nr;
        Title = title;
        CodeText = code;
    }
}

public class CodeText
{
    private readonly string code;
    private readonly string codeFormat;
    private readonly CodeParam[] codeParams;

    public string Code => code;

    public CodeText(
        string codeFormat 
        , CodeParam[] codeParams)
    {
        this.codeFormat = codeFormat;
        this.codeParams = codeParams;
        var names = new List<string>();
        foreach (var param in codeParams)
        {
            names.Add(GetMarkedName(param));
        } 
        code = string.Format(codeFormat, names.ToArray());
    }

    private string GetMarkedName(CodeParam param)
    {
        return $"<mark class=\"{param.CssClass}\">{param.Name}</mark>";
    }

    public string GetParamDescs()
    {
        var sb = new StringBuilder();
        foreach (var param in codeParams)
        {
            sb.AppendLine(GetParamDesc(param));
        }
        return sb.ToString();
    }

    private string? GetParamDesc(CodeParam param)
    {
        return $"                                <p><mark class=\"{param.CssClass}\">{param.Desc}</mark></p>";
    }
}

public record CodeParam(string Name, string Desc, string CssClass);