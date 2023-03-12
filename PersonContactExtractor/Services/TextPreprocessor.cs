using System.Text.RegularExpressions;

namespace PersonContactExtractor.Services;

public class TextPreprocessor : ITextPreprocessor
{
	public string Process(string text)
	{
		var workDirectory = new DirectoryInfo(AppContext.BaseDirectory);
		var baseDirectory = workDirectory.Parent.Parent.Parent.FullName;
		var junkWordsFileName = "JunkWords.txt";
		var junkWordsPath = Path.Combine(baseDirectory, junkWordsFileName);
		var junkWords = System.IO.File.ReadAllLines(junkWordsPath);

		Regex rgxNonAlphaNum = new("[^a-zA-Zа-яА-Я0-9-@+_.«»\"]");
		text = rgxNonAlphaNum.Replace(text, " ");

		Regex rgxQuotation = new("[«»]");
		text = rgxQuotation.Replace(text, "\"");
		foreach(var line in junkWords)
		{
			if(!string.IsNullOrEmpty(line))
				text = text.Replace(line, " ");
		} 
		//Regex rgxWhiteSpaces = new("[[:blank:]]{ 2,}");
		//text = rgxWhiteSpaces.Replace(text, " ");
		return text;
	}
}
