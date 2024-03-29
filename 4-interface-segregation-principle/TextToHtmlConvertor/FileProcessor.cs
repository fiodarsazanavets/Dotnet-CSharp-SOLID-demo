﻿namespace TextToHtmlConvertor;

public class FileProcessor(string fullFilePath) : IFileProcessor
{
    public string ReadAllText()
    {
        return System.Web.HttpUtility.HtmlEncode(File.ReadAllText(fullFilePath));
    }

    public void WriteToFile(string text)
    {
        var outputFilePath = Path.GetDirectoryName(fullFilePath) + 
            Path.DirectorySeparatorChar +
            Path.GetFileNameWithoutExtension(fullFilePath) + ".html";

            using var file = new StreamWriter(outputFilePath);
            file.Write(text);
    }
}