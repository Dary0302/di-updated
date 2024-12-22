using System.Text;
using System.Drawing;
using TagCloudConsoleApp.Interfaces;
using TagsCloudVisualization.Settings;

namespace TagCloudConsoleApp.SettingsProvider;

public class SettingsProvider(string[] args) : ISettingsProvider
{
    private readonly string[] args = args;

    public SettingsManager GetSettings()
    {
        return new(
            new BitmapGeneratorSettings(new(1500, 1500), Color.Black, Color.Peru, new("Arial")),
            new SaveSettings("image","png"),
            new SpiralGeneratorSettings(0, 2, new Point(750, 750)),
            new TextReaderSettings("input.txt", Encoding.UTF8)
        );
    }
}