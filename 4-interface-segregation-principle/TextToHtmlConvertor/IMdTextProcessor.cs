namespace TextToHtmlConvertor;

public interface IMdTextProcessor : ITextProcessor
{
    string ConvertMdText(string inputText);
}