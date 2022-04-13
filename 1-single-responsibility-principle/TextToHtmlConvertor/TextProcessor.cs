using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextToHtmlConvertor;

public class TextProcessor
{
    private readonly FileProcessor fileProcessor;

    public TextProcessor(FileProcessor fileProcessor)
    {
        this.fileProcessor = fileProcessor;
    }

    public void ConvertText()
    {
        var inputText = fileProcessor.ReadAllText();

        var paragraphs = Regex.Split(inputText, @"(\r\n?|\n)")
                            .Where(p => p.Any(char.IsLetterOrDigit));

        var sb = new StringBuilder();

        foreach (var paragraph in paragraphs)
        {
            if (paragraph.Length == 0)
                continue;

            sb.AppendLine($"<p>{paragraph}</p>");
        }

        sb.AppendLine("<br/>");
        fileProcessor.WriteToFile(sb.ToString());
    }
}