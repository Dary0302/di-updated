using System.Drawing;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Interfaces;

public interface IImageSaver
{
    public string SaveImageToFile(Bitmap bitmap, SaveSettings settings);
}