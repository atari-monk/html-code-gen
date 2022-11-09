using System.Text;
using Html.Code.Gen.Lib.Serialize;

namespace Html.Code.Gen.Lib;

public class HtmlGen
{
    public string GetHtml(List<TutorialStep> data)
    {
        var sb = new StringBuilder();
        foreach (var item in data)
        {
            sb.Append(item.GetStepHtml());
        }
        return sb.ToString();
    }
}