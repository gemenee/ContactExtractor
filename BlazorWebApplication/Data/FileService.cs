using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace BlazorWebApplication;

public class FileService : IFileService
{
	private IWebHostEnvironment _environment;

	public FileService(IWebHostEnvironment environment)
	{
		_environment = environment;
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
		var path = Path.Combine(_environment.ContentRootPath,
				"unsafe_uploads", "plain_text",
				fileName);
		await File.WriteAllTextAsync(path, text);
		return await Task.FromResult(fileName);
	}
}