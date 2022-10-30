using System.Text;

namespace Html.Code.Gen.Lib;

public class HtmlGen
{
    public string GetHtml(List<ITutorialStepWithParams> data)
    {
        var sb = new StringBuilder();
        foreach (var item in data)
        {
            sb.Append(item.GetStepHtml());
        }
        return sb.ToString();
    }
}