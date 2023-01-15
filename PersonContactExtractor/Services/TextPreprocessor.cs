using System.Text.RegularExpressions;

namespace PersonContactExtractor.Services;

public class TextPreprocessor : ITextPreprocessor
{
	public string Process(string text)
	{
		Regex rgxNonAlphaNum = new Regex("[^a-zA-Zа-яА-Я0-9 - @ + _ .]");
		text = rgxNonAlphaNum.Replace(text, " ");
		Regex rgxWhiteSpaces = new("[[:blank:]]{ 2,}");
		text = rgxWhiteSpaces.Replace(text, " ");
		return text;
	}
}
