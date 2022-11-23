namespace Html.Code.Gen.Lib;

public class InsertGenerator : IHtmlGeneratorAsync
{
    private readonly IAsyncEnumerable<string> data;
    private readonly int columns;

    public InsertGenerator(string path, int columns)
    {
        data = File.ReadLinesAsync(path);
        this.columns = columns;
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
            Console.Write("(");
            var i = 0;
            foreach (var item in line.Split(','))
            {
                if (i == 0) { }
                else
                {
                    if (i < columns)
                        Console.Write("'" + item + "',");
                    if (i == columns)
                        Console.Write("'" + item + "'");
                }
                i++;
            }
            Console.WriteLine("),");
        }
    }
}