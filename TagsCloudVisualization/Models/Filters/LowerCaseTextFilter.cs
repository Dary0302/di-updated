using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization.Models.Filters;

public class LowerCaseTextFilter : ITextFilter
{
    public IEnumerable<string> ApplyFilter(IEnumerable<string> text)
    {
        return text.Select(word => word.ToLower());
    }
}