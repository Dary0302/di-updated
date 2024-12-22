using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization.Models.Filters;

public class LowerCaseTextFilter : ITextFilter
{
    public List<string> ApplyFilter(IEnumerable<string> text)
    {
        return text.Select(word => word.ToLower()).ToList();
    }
}