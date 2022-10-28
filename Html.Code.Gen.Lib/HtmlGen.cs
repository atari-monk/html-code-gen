using System.Text;

namespace Html.Code.Gen.Lib;

public class HtmlGen
{
    public string GetHtml(List<TutorialStep> data)
    {
        var sb = new StringBuilder();
        foreach (var item in data)
        {
            sb.Append(GetHtml(item));
        }
        return sb.ToString();
    }

    public string GetHtml(TutorialStep data)
    {
        var html = new StringBuilder();
        /*
                    <li>
                        <p>
                            Step title
                        </p>
                        <aside>
                            <details>
                                <summary>details</summary>
                                <p><mark>choose your x</mark></p>
                                <p><mark>choose your y</mark></p>
                            </details>
                        </aside>
                        <p>
                            <button onclick="Copy('codex')">Copy</button>
                            <code id="codex">
                                <mark class="mark-resource-group">CommonResourceGroup</mark>
                                <mark class="mark-location">swedencentral</mark>
                                <mark class="mark-acr">atarimonkacr</mark>
                            </code>
                        </p>
                    </li>
        */
        html.AppendLine("                    <li>");
        html.AppendLine("                       <p>");
        html.AppendLine($"                           {data.Title}");
        html.AppendLine("                       </p>");
        html.AppendLine("                       <aside>");
        html.AppendLine("                            <details>");
        html.AppendLine("                                <summary>details</summary>");
        html.AppendLine("                            </details>");
        html.AppendLine("                        </aside>");
        html.AppendLine("                        <p>");
        html.AppendLine($"                           <button onclick=\"Copy('code{data.Nr}')\">Copy</button>");
        html.AppendLine($"                           <code id='code{data.Nr}'>");
        html.AppendLine($"                               {data.Code}");
        html.AppendLine("                            </code>");
        html.AppendLine("                        </p>");
        html.AppendLine("                    </li>");
        return html.ToString();
    }
}