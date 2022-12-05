namespace TextPreparation
{
	public interface IDocxTextExtractor
	{
		public void SaveTextToFile(string text);

		public string ExtractText(string fullFileName);
	}
}