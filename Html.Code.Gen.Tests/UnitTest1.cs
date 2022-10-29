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
        var data = new TutorialStep(
            1
            , "Create resource group"
            , new CodeText(
                "az group create --name {0} --location {1}"
                , new CodeParam[] {
                    new CodeParam(
                        "CommonResourceGroup"
                        , "choose your resource group name"
                        , "mark-resource-group")
                    , new CodeParam(
                        "swedencentral"
                        , "choose your location"
                        , "mark-location")
                }));
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
        expected.AppendLine("                        <p>");
       expected.AppendLine($"                           <button onclick=\"Copy('code1')\">Copy</button>");
       expected.AppendLine($"                           <code id='code1'>");
       expected.AppendLine($"                               az group create --name <mark class=\"mark-resource-group\">CommonResourceGroup</mark> --location <mark class=\"mark-location\">swedencentral</mark>");
        expected.AppendLine("                           </code>");
        expected.AppendLine("                        </p>");
        expected.AppendLine("                    </li>");

        //test
        var actual = gen.GetHtml(data);

        //File.WriteAllText(@"C:\atari-monk\Doc\expected.html", expected.ToString());
        //File.WriteAllText(@"C:\atari-monk\Doc\actual.html", actual);

        //assert
        Assert.Equal(expected.ToString(), actual);
    }
}