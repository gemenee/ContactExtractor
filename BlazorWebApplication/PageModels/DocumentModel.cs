namespace BlazorWebApplication;

public class DocumentModel
{
	public string OriginFileName { get; set; }
	public string FilePath { get; set; }
	public string? PlainTextFilePath { get; set; }
	public long Size { get; set; }
	public bool IsProcessed { get; set; }
}