namespace PersonContactExtractor.Services;

public class FileService : IFileService
{
	private readonly string _contentRootPath;

	public FileService(string contentRootPath)
	{
        _contentRootPath = contentRootPath;
	}

	public FileInfo[] GetUploadedFiles()
	{
		var files = Directory.GetFiles("/unsafe_uploads");
		var fileInfos = new List<FileInfo>();
		foreach (var file in files)
		{
			fileInfos.Add(new FileInfo(file));
		}
		return fileInfos.ToArray();
	}

	public async Task<string> SaveTextToFileAsync(string text)
	{
		var fileName = Path.GetRandomFileName();
		var path = Path.Combine(_contentRootPath,
				"unsafe_uploads", "plain_text",
				fileName);
		await File.WriteAllTextAsync(path, text);
		return await Task.FromResult(fileName);
	}
}