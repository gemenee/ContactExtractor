using Microsoft.EntityFrameworkCore;
using PersonContactExtractor.Persistance;
using TextPreparation;

namespace BlazorWebApplication;

public class DocumentService : IDocumentService
{
	private ContactExtractorContext _db;
	private IDocxTextExtractor _docxTextExtractor;
	private IFileService _fileService;

	public DocumentService(ContactExtractorContext db, IDocxTextExtractor docxTextExtractor, IFileService fileService)
	{
		_db = db;
		_docxTextExtractor = docxTextExtractor;
		_fileService = fileService;
	}

	public DocumentModel[] GetDocuments()
	{
		var result = new List<DocumentModel>();
		foreach (var doc in _db.Documents.AsNoTracking())
		{
			result.Add(new DocumentModel()
			{
				Id = doc.Id,
				OriginFileName = doc.OriginFileName,
				UploadDate = doc.CreationDateTimeUtc.ToShortDateString(),
				Size = doc.SizeInBytes,
				IsProcessed = doc.Processed,
				PlainTextFilePath = doc.PlainTextFilePath
			});
		}

		return result.ToArray();
	}

	public async Task AddAsync(string FilePath, string originFileName)
	{
		var file = new FileInfo(FilePath);
		var text = _docxTextExtractor.ExtractText(FilePath);
		var plainTextFileName = await _fileService.SaveTextToFileAsync(text);
		await _db.Documents.AddAsync(new DocumentEntity
		{
			OriginFileName = originFileName,
			CreationDateTimeUtc = DateTime.UtcNow,
			SizeInBytes = file.Length,
			FilePath = file.FullName,
			PlainTextFilePath = plainTextFileName
		});
		await _db.SaveChangesAsync();
	}

	public async Task DeleteAsync(int documentId)
	{
		var document = new DocumentEntity { Id= documentId };
		_db.Attach(document);
		_db.Remove(document);
		_db.SaveChangesAsync();
	}
}