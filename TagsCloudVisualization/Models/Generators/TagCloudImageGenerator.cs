using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Interfaces;
using TagsCloudVisualization.Models.Selectors;

namespace TagsCloudVisualization.Models.Generators;

public class TagCloudImageGenerator(
    IImageSaver saver,
    SaveSettings saveSettings,
    TextSettings textSettings,
    FileReadersSelector fileReadersSelector,
    IBitmapGenerator bitmapGenerator,
    IEnumerable<ITextFilter> filters)
{
    private readonly int maxFontSize = textSettings.MaxFontSize;
    private readonly int minFontSize = textSettings.MinFontSize;
    private int maxWordCount;
    private int minWordCount;

    public void GenerateCloud()
    {
        var text = fileReadersSelector.SelectFileReader().ReadText();

        var wordsFrequency = filters
            .Aggregate(text, (word, filter) => filter.ApplyFilter(word))
            .GroupBy(w => w)
            .OrderByDescending(words => words.Count())
            .ToDictionary(words => words.Key, words => words.Count());

        minWordCount = wordsFrequency.Values.Min();
        maxWordCount = wordsFrequency.Values.Max();

        var words = wordsFrequency
            .Select(w => new TagWord(w.Key, GetFontSize(w.Value)));

        var bitmap = bitmapGenerator.GenerateBitmap(words);
        saver.SaveImageToFile(bitmap, saveSettings);
    }

    private int GetFontSize(int frequencyCount) =>
        minFontSize + (maxFontSize - minFontSize)
        * (frequencyCount - minWordCount) / (maxWordCount - minWordCount);
}