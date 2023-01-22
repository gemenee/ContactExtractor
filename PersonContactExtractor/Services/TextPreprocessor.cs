using System;
using System.IO;
using System.Text.RegularExpressions;
using PersonContactExtractor.Persistance;

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

		Regex rgxNonAlphaNum = new Regex("[^a-zA-Zа-яА-Я0-9 - @ + _ .]");
		text = rgxNonAlphaNum.Replace(text, " ");
		foreach(var line in junkWords)
		{
			if(!string.IsNullOrEmpty(line))
				text.Replace(line, " ");
		} 
		//Regex rgxWhiteSpaces = new("[[:blank:]]{ 2,}");
		//text = rgxWhiteSpaces.Replace(text, " ");
		return text;
	}
}
