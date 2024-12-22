using System.Drawing;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization.Models.Savers;

public class ImageSaver : IImageSaver
{
    public string SaveImageToFile(Bitmap bitmap, SaveSettings settings)
    {
        #pragma warning disable CA1416
        bitmap.Save($"{settings.Filename}.{settings.Format}", settings.ImageFormat);
        #pragma warning restore CA1416
        Console.WriteLine($"Tag cloud visualization saved to: {Path.GetFullPath(settings.Filename)}.{settings.Format}");

        return Path.GetFullPath(settings.Filename);
    }
}