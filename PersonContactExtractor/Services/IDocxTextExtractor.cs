namespace PersonContactExtractor.Services;

public interface IDocxTextExtractor
{
    public void SaveTextToFile(string text);

    public string ExtractText(string fullFileName);
}