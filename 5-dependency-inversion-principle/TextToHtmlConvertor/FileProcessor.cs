using System.Web;

namespace TextToHtmlConvertor;

public class FileProcessor(string fullFilePath) : IFileProcessor
{
    private readonly string fullFilePath = fullFilePath;

    public string ReadAllText()
    {
        return HttpUtility.HtmlEncode(File.ReadAllText(fullFilePath));
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