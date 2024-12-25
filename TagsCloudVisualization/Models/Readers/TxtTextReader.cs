using System.Text;
using TagsCloudVisualization.Interfaces;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Models.Readers;

public class TxtTextReader(TextReaderSettings settings) : ITextReader
{
    public IEnumerable<string> ReadText()
    {
        return File.ReadLines(settings.Path, settings.Encoding);
    }

    public IEnumerable<string> ReadText(string path)
    {
        return File.ReadLines(path, settings.Encoding);
    }
}