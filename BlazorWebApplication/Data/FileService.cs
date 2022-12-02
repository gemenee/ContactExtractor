using System.IO;

namespace BlazorWebApplication;

public class FileService
{
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
}