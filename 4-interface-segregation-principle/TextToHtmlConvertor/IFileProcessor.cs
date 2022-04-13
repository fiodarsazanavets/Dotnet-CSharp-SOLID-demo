namespace TextToHtmlConvertor;

public interface IFileProcessor
{
    string ReadAllText();
    void WriteToFile(string text);
}