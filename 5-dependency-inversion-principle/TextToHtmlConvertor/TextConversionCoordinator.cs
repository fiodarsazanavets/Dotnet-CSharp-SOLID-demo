namespace TextToHtmlConvertor;

public class TextConversionCoordinator
{
    private readonly IFileProcessor fileProcessor;
    private readonly IMdTextProcessor textProcessor;

    public TextConversionCoordinator(IFileProcessor fileProcessor, IMdTextProcessor textProcessor)
    {
        this.fileProcessor = fileProcessor;
        this.textProcessor = textProcessor;
    }

    public ConversionStatus ConvertText()
    {
        var status = new ConversionStatus();
        string inputText;
        try
        {
            inputText = fileProcessor.ReadAllText();
            status.TextExtractedFromFile = true;
        }
        catch (Exception ex)
        {
            status.Errors.Add(ex.Message);
            return status;
        }

        string outputText;
        try
        {
            outputText = textProcessor.ConvertMdText(inputText);

            if (outputText != inputText)
                status.TextConverted = true;
        }
        catch (Exception ex)
        {
            status.Errors.Add(ex.Message);
            return status;
        }

        try
        {
            fileProcessor.WriteToFile(outputText);
            status.OutputFileSaved = true;
        }
        catch (Exception ex)
        {
            status.Errors.Add(ex.Message);
            return status;
        }

        return status;
    }
}