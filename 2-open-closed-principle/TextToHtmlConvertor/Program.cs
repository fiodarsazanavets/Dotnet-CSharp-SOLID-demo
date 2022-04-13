﻿using TextToHtmlConvertor;

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
    var inputText = fileProcessor.ReadAllText();
    var outputText = textProcessor.ConvertText(inputText);
    fileProcessor.WriteToFile(outputText);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();