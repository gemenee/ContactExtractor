using Microsoft.EntityFrameworkCore;
using PersonContactExtractor.Persistance;

namespace BlazorWebApplication;

public class DocumentService : IDocumentService
{
	private ContactExtractorContext _db;

	public DocumentService(ContactExtractorContext db)
	{
		_db = db;
	}

	public DocumentModel[] GetDocuments()
	{
		var result = new List<DocumentModel>();
		foreach (var doc in _db.Documents)
		{
			result.Add(new DocumentModel()
			{
				OriginFileName = doc.OriginFileName,
				Size = doc.SizeInBytes,
				IsProcessed = doc.Processed,
			});
		}

		return result.ToArray();
	}

	public async Task AddAsync(string FilePath, string originFileName)
	{
		var file = new FileInfo(FilePath);

		_db.Documents.Add(new DocumentEntity
		{
			OriginFileName = originFileName,
			CreationDateTimeUtc = DateTime.UtcNow,
			SizeInBytes = file.Length,
			FilePath = file.FullName
		});
		await _db.SaveChangesAsync();
	}
}