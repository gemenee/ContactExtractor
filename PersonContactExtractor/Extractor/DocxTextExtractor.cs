using System.IO;
using System.Text.RegularExpressions;
using Xceed.Words.NET;

namespace TextPreparation
{
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
				result = document.Text;
			}

			return result;
		}

		public void SaveTextToFile(string text)
		{
		}

		public static string RemoveNonAlphanumericSymbols(string text)
		{
			Regex rgxNonAlphaNum = new Regex("[^a-zA-Zа-яА-Я0-9 -]");
			text = rgxNonAlphaNum.Replace(text, " ");
			Regex rgxWhiteSpaces = new Regex("[[:blank:]]{ 2,}");
			return rgxWhiteSpaces.Replace(text, "");
		}
	}
}