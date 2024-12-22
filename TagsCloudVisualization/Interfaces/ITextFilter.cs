namespace TagsCloudVisualization.Interfaces;

public interface ITextFilter
{
    public List<string> ApplyFilter(IEnumerable<string> text);
}