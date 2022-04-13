using Moq;
using TextToHtmlConvertor;
using Xunit;

namespace TextToHtmlConvertorTests;

public class TextConversionCoordinatorTests
{
    private readonly TextConversionCoordinator coordinator;
    private readonly Mock<IFileProcessor> fileProcessorMoq;
    private readonly Mock<IMdTextProcessor> textProcessorMoq;

    public TextConversionCoordinatorTests()
    {
        fileProcessorMoq = new Mock<IFileProcessor>();
        textProcessorMoq = new Mock<IMdTextProcessor>();
        coordinator = new TextConversionCoordinator(fileProcessorMoq.Object, textProcessorMoq.Object);
    }


    // This is a scenario that tests TextConversionCoordinator under the normal circumstances.
    // The dependency methods have been set up for successful conversion.
    [Fact]
    public void CanProcessText()
    {
        fileProcessorMoq.Setup(p => p.ReadAllText()).Returns("input");
        textProcessorMoq.Setup(p => p.ConvertMdText("input")).Returns("altered input");

        var status = coordinator.ConvertText();

        Assert.True(status.TextExtractedFromFile);
        Assert.True(status.TextConverted);
        Assert.True(status.OutputFileSaved);
        Assert.Empty(status.Errors);
    }

    // This is a scenario that tests TextConversionCoordinator where the text hasn't been changed.
    // The dependency methods have been set up accordingly.
    [Fact]
    public void CanDetectUnconvertedText()
    {
        fileProcessorMoq.Setup(p => p.ReadAllText()).Returns("input");
        textProcessorMoq.Setup(p => p.ConvertMdText("input")).Returns("input");

        var status = coordinator.ConvertText();

        Assert.True(status.TextExtractedFromFile);
        Assert.False(status.TextConverted);
        Assert.True(status.OutputFileSaved);
        Assert.Empty(status.Errors);
    }

    // This is a scenario that tests TextConversionCoordinator where the text hasn't been read.
    // The dependency methods have been set up accordingly.
    [Fact]
    public void CanDetectUnsuccessfulRead()
    {
        fileProcessorMoq.Setup(p => p.ReadAllText()).Throws(new Exception("Read error occurred."));

        var status = coordinator.ConvertText();

        Assert.False(status.TextExtractedFromFile);
        Assert.False(status.TextConverted);
        Assert.False(status.OutputFileSaved);
        Assert.Single(status.Errors);
        Assert.Equal("Read error occurred.", status.Errors.First());
    }

    // This is a scenario that tests TextConversionCoordinator where an attempt to convert the text thrown an error.
    // The dependency methods have been set up accordingly.
    [Fact]
    public void CanDetectUnsuccessfulConvert()
    {
        fileProcessorMoq.Setup(p => p.ReadAllText()).Returns("input");
        textProcessorMoq.Setup(p => p.ConvertMdText("input")).Throws(new Exception("Convert error occurred."));

        var status = coordinator.ConvertText();

        Assert.True(status.TextExtractedFromFile);
        Assert.False(status.TextConverted);
        Assert.False(status.OutputFileSaved);
        Assert.Single(status.Errors);
        Assert.Equal("Convert error occurred.", status.Errors.First());
    }

    // This is a scenario that tests TextConversionCoordinator where an attempt to save the file thrown an error.
    // The dependency methods have been set up accordingly.
    [Fact]
    public void CanDetectUnsuccessfulSave()
    {
        fileProcessorMoq.Setup(p => p.ReadAllText()).Returns("input");
        textProcessorMoq.Setup(p => p.ConvertMdText("input")).Returns("altered input");
        fileProcessorMoq.Setup(p => p.WriteToFile("altered input")).Throws(new Exception("Unable to save file."));

        var status = coordinator.ConvertText();

        Assert.True(status.TextExtractedFromFile);
        Assert.True(status.TextConverted);
        Assert.False(status.OutputFileSaved);
        Assert.Single(status.Errors);
        Assert.Equal("Unable to save file.", status.Errors.First());
    }
}
