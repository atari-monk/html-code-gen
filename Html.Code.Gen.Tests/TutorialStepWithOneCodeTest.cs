using System.Text;
using Html.Code.Gen.Lib.Serialize;
using CodeParam = Html.Code.Gen.Lib.Serialize.CodeParam;

namespace expected.Code.Gen.Tests;

public class TutorialStepWithOneCodeTest
{
    [Fact]
    public void TestTemplateWithOneCode()
    {
        //setup
        var data = new TutorialStep
        {
            Title = "Create resource group",
            Codes = new CodeElement[] {
                new CodeElement{
                    Nr = 1
                    , CodeFormat = "az group create --name {0} --location {1}"
                    , CodeParams = new CodeParam[] {
                        new CodeParam {
                            Name = "CommonResourceGroup"
                            , Desc = "choose your resource group name"
                            , CssClass = "mark-resource-group"
                        }
                        , new CodeParam {
                            Name = "swedencentral"
                            , Desc = "choose your location"
                            , CssClass = "mark-location"
                        }
                    }
                }
            }
        };
        var expected = new StringBuilder();
        expected.AppendLine("                    <li>");
        expected.AppendLine("                       <p>");
        expected.AppendLine("                           Create resource group");
        expected.AppendLine("                       </p>");
        expected.AppendLine("                       <aside>");
        expected.AppendLine("                            <details>");
        expected.AppendLine("                                <summary>details</summary>");
        expected.AppendLine("                                <p><mark class=\"mark-resource-group\">choose your resource group name</mark></p>");
        expected.AppendLine("                                <p><mark class=\"mark-location\">choose your location</mark></p>");
        expected.AppendLine("                            </details>");
        expected.AppendLine("                        </aside>");
        expected.AppendLine("                       <p>");
        expected.AppendLine($"                           <button onclick=\"Copy('code1')\">Copy</button>");
        expected.AppendLine($"                           <code id='code1'>");
        expected.AppendLine($"                               az group create --name <mark class=\"mark-resource-group\">CommonResourceGroup</mark> --location <mark class=\"mark-location\">swedencentral</mark>");
        expected.AppendLine("                           </code>");
        expected.AppendLine("                       </p>");
        expected.AppendLine("                    </li>");

        //test
        var actual = data.GetStepHtml();

        //File.WriteAllText(@"C:\atari-monk\Doc\expected.html", expected.ToString());
        //File.WriteAllText(@"C:\atari-monk\Doc\actual.html", actual);

        //assert
        Assert.Equal(expected.ToString(), actual);
    }
}