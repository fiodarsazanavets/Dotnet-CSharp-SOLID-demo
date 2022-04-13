namespace TextToHtmlConvertor;

public class ConversionStatus
{
    public bool TextExtractedFromFile { get; set; }
    public bool TextConverted { get; set; }
    public bool OutputFileSaved { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
}
