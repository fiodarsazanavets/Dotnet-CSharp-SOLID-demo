using TextToHtmlConvertor;
using Xunit;

namespace TextToHtmlConvertorTests;

public class TextProcessorTests
{
    private readonly TextProcessor textProcessor;

    public TextProcessorTests()
    {
        var tagsToReplace = new Dictionary<string, (string, string)>
            {
                { "**", ("<strong>", "</strong>") },
                { "*", ("<em>", "</em>") },
                { "~~", ("<del>", "</del>") }
            };

        textProcessor = new MdTextProcessor(tagsToReplace);
    }

    [Fact]
    public void CanConvertText()
    {
        var originalText = "This is the first paragraph. It has * and *.\r\n" +
            "This is the second paragraph. It has ** and **.";

        var expectedSting = "<p>This is the first paragraph. It has * and *.</p>\r\n" +
            "<p>This is the second paragraph. It has ** and **.</p>\r\n" +
            "<br/>\r\n";

        Assert.Equal(expectedSting, textProcessor.ConvertText(originalText));
    }
}