using System.Text;
using Xceed.Words.NET;

namespace PersonContactExtractor.Services;

public class DocxTextExtractor : IDocxTextExtractor
{
	public string ExtractText(FileInfo file)
	{
		string result;
		using (var document = DocX.Load(file.FullName))
		{
			result = document.Text;
		}

		return result;
	}

	public string ExtractText(string fullFileName)
	{
		string result;
		using (var document = DocX.Load(fullFileName))
		{
			var sb = new StringBuilder();
			foreach(var p in document.Paragraphs)
			{
				if(!string.IsNullOrWhiteSpace(p.Text))
					sb.AppendLine(p.Text);
			}

			result = sb.ToString();
		}

		return result;
	}

	public void SaveTextToFile(string text)
	{

	}
}