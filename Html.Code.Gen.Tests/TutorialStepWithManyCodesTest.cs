using System.Text;
using Html.Code.Gen.Lib.Serialize;

namespace expected.Code.Gen.Tests;

public class TutorialStepWithManyCodesTest
{
    [Fact]
    public void TestTemplateWithManyCodes()
    {
        //setup
        var data = new TutorialStep
        {
            Title = "Run locally",
            Codes = new CodeElement[] {
                new CodeElement{
                    Nr = 1,
                    CodeFormat = "docker-compose up --build -d"
                },
                new CodeElement{
                    Nr = 2,
                    CodeFormat = "docker images"
                },
                new CodeElement{
                    Nr = 3,
                    CodeFormat = "docker ps"
                },
            }
        };
        var expected = new StringBuilder();
        expected.AppendLine("                    <li>");
        expected.AppendLine("                       <p>");
        expected.AppendLine("                           Run locally");
        expected.AppendLine("                       </p>");
        expected.AppendLine("                       <p>");
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