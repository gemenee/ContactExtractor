namespace PersonContactExtractor.Persistance.Entities;

public class DocumentEntity : BaseEntity
{
    public string OriginFileName { get; set; }
    public string FilePath { get; set; }
    public string PlainTextFilePath { get; set; }
    public DocumentResultEntity DocumentResult { get; set; }
}