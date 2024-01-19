using System.Web;

namespace TextToHtmlConvertor;

public class FileProcessor(string fullFilePath)
{
    public string ReadAllText()
    {
        return HttpUtility.HtmlEncode(File.ReadAllText(fullFilePath));
    }

    public void WriteToFile(string text)
    {
        string outputFilePath = Path.GetDirectoryName(fullFilePath) + 
            Path.DirectorySeparatorChar +
            Path.GetFileNameWithoutExtension(fullFilePath) + ".html";

        using StreamWriter file = new(outputFilePath);
        file.Write(text);
    }
}