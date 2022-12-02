namespace PersonContactExtractor.Persistance;

public class DocumentEntity : BaseEntity
{
	public string OriginFileName { get; set; }
	public string FilePath { get; set; }
	public long SizeInBytes { get; set; }
	public string? PlainTextFilePath { get; set; }
	public bool Processed { get; set; } = false;
	public DocumentResultEntity? DocumentResult { get; set; }
}