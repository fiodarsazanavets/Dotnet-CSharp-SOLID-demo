using System.IO;

namespace TextToHtmlConvertor
{
    public class FileProcessor
    {
        private readonly string fullFilePath;

        public FileProcessor(string fullFilePath)
        {
            this.fullFilePath = fullFilePath;
        }

        public string ReadAllText()
        {
            return System.Web.HttpUtility.HtmlEncode(File.ReadAllText(fullFilePath));
        }

        public void WriteToFile(string text)
        {
            var outputFilePath = Path.GetDirectoryName(fullFilePath) + Path.DirectorySeparatorChar +
                Path.GetFileNameWithoutExtension(fullFilePath) + ".html";

            using (StreamWriter file =
            new StreamWriter(outputFilePath))
            {
                file.Write(text);
            }
        }
    }
}
