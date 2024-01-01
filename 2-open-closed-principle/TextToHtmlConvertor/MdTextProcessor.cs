﻿namespace TextToHtmlConvertor;

public class MdTextProcessor(Dictionary<string, (string, string)> tagsToReplace) : TextProcessor
{
    public override string ConvertText(string inputText)
    {
        var processedText = base.ConvertText(inputText);

        foreach (var key in tagsToReplace.Keys)
        {
            var replacementTags = tagsToReplace[key];

            if (CountStringOccurrences(processedText, key) % 2 == 0)
                processedText = ApplyTagReplacement(processedText, key, replacementTags.Item1, replacementTags.Item2);
        }

        return processedText;
    }

    private static int CountStringOccurrences(string text, string pattern)
    {
        int count = 0;
        int currentIndex = 0;
        while ((currentIndex = text.IndexOf(pattern, currentIndex)) != -1)
        {
            currentIndex += pattern.Length;
            count++;
        }
        return count;
    }

    private static string ApplyTagReplacement(string text, string inputTag, string outputOpeningTag, string outputClosingTag)
    {
        int count = 0;
        int currentIndex = 0;

        while ((currentIndex = text.IndexOf(inputTag, currentIndex)) != -1)
        {
            count++;

            if (count % 2 != 0)
            {
                var prepend = outputOpeningTag;
                text = text.Insert(currentIndex, prepend);
                currentIndex += prepend.Length + inputTag.Length;
            }
            else
            {
                var append = outputClosingTag;
                text = text.Insert(currentIndex, append);
                currentIndex += append.Length + inputTag.Length;
            }
        }

        return text.Replace(inputTag, string.Empty);
    }
}