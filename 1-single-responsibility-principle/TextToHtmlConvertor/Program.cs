using TextToHtmlConvertor;

try
{
    Console.WriteLine("Please specify the file to convert to HTML.");
    var fullFilePath = Console.ReadLine() ?? string.Empty;
    var fileProcessor = new FileProcessor(fullFilePath);
    var textProcessor = new TextProcessor(fileProcessor);
    textProcessor.ConvertText();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();