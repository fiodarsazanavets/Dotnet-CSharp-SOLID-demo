using TextToHtmlConvertor;

try
{
    Console.WriteLine("Please specify the file to convert to HTML.");
    var fullFilePath = Console.ReadLine();
    var fileProcessor = new FileProcessor(fullFilePath);
    var tagsToReplace = new Dictionary<string, (string, string)>
    {
        { "**", ("<strong>", "</strong>") },
        { "*", ("<em>", "</em>") },
        { "~~", ("<del>", "</del>") }
    };

    var textProcessor = new MdTextProcessor(tagsToReplace);
    var coordinator = new TextConversionCoordinator(fileProcessor, textProcessor);
    var status = coordinator.ConvertText();

    Console.WriteLine($"Text extracted from file: {status.TextExtractedFromFile}");
    Console.WriteLine($"Text converted: {status.TextConverted}");
    Console.WriteLine($"Output file saved: {status.OutputFileSaved}");

    if (status.Errors.Count > 0)
    {
        Console.WriteLine("The following errors occured during the conversion:");
        Console.WriteLine(string.Empty);

        foreach (var error in status.Errors)
            Console.WriteLine(error);

    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();