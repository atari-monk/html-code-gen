using System.Text;
using Html.Code.Gen.Lib;

namespace expected.Code.Gen.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //setup
        var gen = new HtmlGen();
        var data = new TutorialStep{
            Nr = 1,
            Title = "Create resource group",
            Code = $"az group create --name CommonResourceGroup --location swedencentral",
        };
        var expected = new StringBuilder();
        expected.AppendLine("                    <li>");
        expected.AppendLine("                       <p>");
        expected.AppendLine($"                           {data.Title}");
        expected.AppendLine("                       </p>");
        expected.AppendLine("                       <aside>");
        expected.AppendLine("                            <details>");
        expected.AppendLine("                                <summary>details</summary>");
        expected.AppendLine("                            </details>");
        expected.AppendLine("                        </aside>");
        expected.AppendLine("                        <p>");
        expected.AppendLine($"                           <button onclick=\"Copy('code{data.Nr}')\">Copy</button>");
        expected.AppendLine($"                           <code id='code{data.Nr}'>");
        expected.AppendLine($"                               {data.Code}");
        expected.AppendLine("                            </code>");
        expected.AppendLine("                        </p>");
        expected.AppendLine("                    </li>");
        
        //test
        var actual = gen.GetHtml(data);

        //assert
        Assert.Equal(expected.ToString(), actual);
    }
}