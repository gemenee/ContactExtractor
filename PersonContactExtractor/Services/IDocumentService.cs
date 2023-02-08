namespace PersonContactExtractor.Services;

public interface IDocumentService
{
    public DocumentModel[] GetDocuments();

    public Task AddAsync(string FilePath, string originFileName);
    public Task DeleteAsync(int documentId);
}