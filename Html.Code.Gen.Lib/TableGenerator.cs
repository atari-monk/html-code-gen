namespace Html.Code.Gen.Lib;

public class TableGenerator : IHtmlGeneratorAsync
{
    private readonly IAsyncEnumerable<string> data;

    public TableGenerator(string path)
    {
        data = File.ReadLinesAsync(path);
    }

    public async Task GenerateHtmlFilesAsync()
    {
        await foreach (var line in data)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
        Console.WriteLine();
        await foreach (var line in data)
        {
            Console.WriteLine("<tr>");
            var i = 0;
            foreach (var item in line.Split(','))
            {
                if (i == 0)
                {
                    Console.WriteLine("<th scope='row'>" + item + "</th>");
                }
                else
                {
                    Console.WriteLine("<td>" + item + "</td>");
                }
                i++;
            }
            Console.WriteLine("</tr>");
        }
    }
}