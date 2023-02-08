namespace PersonContactExtractor.Services;

	public interface IFileService
	{
		FileInfo[] GetUploadedFiles();
		Task<string> SaveTextToFileAsync(string text);
	}