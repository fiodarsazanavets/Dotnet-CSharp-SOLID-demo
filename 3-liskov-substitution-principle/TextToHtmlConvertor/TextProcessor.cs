using System.Text;
using System.Text.RegularExpressions;

namespace TextToHtmlConvertor;

public class TextProcessor
{
    public virtual string ConvertText(string inputText)
    {
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

        return sb.ToString();
    }
}