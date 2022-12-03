namespace BlazorWebApplication
{
	public interface IFileService
	{
		FileInfo[] GetUploadedFiles();
		Task<string> SaveTextToFileAsync(string text);
	}
}