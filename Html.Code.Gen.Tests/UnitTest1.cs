using System.Text;
using Html.Code.Gen.Lib;

namespace expected.Code.Gen.Tests;

public class UnitTest1
{
    [Fact]
    public void TestTemplateWithOneCode()
    {
        //setup
        var data = new TutorialStepWithParams(
            "Create resource group"
            , new CodeWithParams[] { new CodeWithParams(
                1
                , "az group create --name {0} --location {1}"
                , new CodeParam[] {
                    new CodeParam(
                        "CommonResourceGroup"
                        , "choose your resource group name"
                        , "mark-resource-group")
                    , new CodeParam(
                        "swedencentral"
                        , "choose your location"
                        , "mark-location")
                })});
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
        var actual = data.GetStepHtml();

        //File.WriteAllText(@"C:\atari-monk\Doc\expected.html", expected.ToString());
        //File.WriteAllText(@"C:\atari-monk\Doc\actual.html", actual);

        //assert
        Assert.Equal(expected.ToString(), actual);
    }

    [Fact]
    public void TestTemplateWithManyCodes()
    {
        //setup
        var data = new TutorialStepWithNoParams(
            "Run locally"
            , new CodeWithNoParams[] { 
                new CodeWithNoParams(1, "docker-compose up --build -d")
                , new CodeWithNoParams(2, "docker images")
                , new CodeWithNoParams(3, "docker ps")});
        var expected = new StringBuilder();
        expected.AppendLine("                    <li>");
        expected.AppendLine("                       <p>");
        expected.AppendLine("                           Run locally");
        expected.AppendLine("                       </p>");
        // expected.AppendLine("                       <aside>");
        // expected.AppendLine("                            <details>");
        // expected.AppendLine("                                <summary>details</summary>");
        // expected.AppendLine("                                <p><mark class=\"mark-resource-group\">choose your resource group name</mark></p>");
        // expected.AppendLine("                                <p><mark class=\"mark-location\">choose your location</mark></p>");
        // expected.AppendLine("                            </details>");
        // expected.AppendLine("                        </aside>");
        expected.AppendLine("                        <p>");
       expected.AppendLine($"                           <button onclick=\"Copy('code1')\">Copy</button>");
       expected.AppendLine($"                           <code id='code1'>");
       expected.AppendLine($"                               docker-compose up --build -d");
        expected.AppendLine("                           </code>");
       expected.AppendLine($"                           <button onclick=\"Copy('code2')\">Copy</button>");
       expected.AppendLine($"                           <code id='code2'>");
       expected.AppendLine($"                               docker images");
        expected.AppendLine("                           </code>");
       expected.AppendLine($"                           <button onclick=\"Copy('code3')\">Copy</button>");
       expected.AppendLine($"                           <code id='code3'>");
       expected.AppendLine($"                               docker ps");
        expected.AppendLine("                           </code>");
        expected.AppendLine("                        </p>");
        expected.AppendLine("                    </li>");

        //test
        var actual = data.GetStepHtml();

        //File.WriteAllText(@"C:\atari-monk\Doc\expected.html", expected.ToString());
        //File.WriteAllText(@"C:\atari-monk\Doc\actual.html", actual);

        //assert
        Assert.Equal(expected.ToString(), actual);
    }
}