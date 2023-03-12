using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PersonContactExtractor.Persistance;
using WebApplication.Dto;

namespace PersonContactExtractor.Services;

public partial class DocumentProcessor : IDocumentProcessor
{
	private readonly string _fileDirectoryPath = Path.Combine("unsafe_uploads", "plain_text");
	private readonly IHttpClientFactory _clientFactory;
	private readonly ContactExtractorContext _contactExtractorContext;
	private readonly ITextPreprocessor _preprocessor;
	private readonly IResponseConverter _responseConverter;

	public DocumentProcessor(
		IHttpClientFactory clientFactory,
		ContactExtractorContext contactExtractorContext,
		ITextPreprocessor textPreprocessor,
		IResponseConverter responseConverter)
	{
		_clientFactory = clientFactory;
		_contactExtractorContext = contactExtractorContext;
		_preprocessor = textPreprocessor;
		_responseConverter = responseConverter;
	}

	public async Task ProcessDocumentAsync(int documentId)
	{
		var workDirectory = new DirectoryInfo(AppContext.BaseDirectory);
		var baseDirectory = workDirectory.Parent.Parent.Parent.FullName;
		var txtFilePath = (await _contactExtractorContext.Documents.FirstOrDefaultAsync(d => d.Id == documentId)).PlainTextFilePath;
		var serverAddress = "flask-extractor";
		var request = new HttpRequestMessage(HttpMethod.Post,
			$"http://host.docker.internal:5000/extract");
		var text = File.ReadAllText(Path.Combine(baseDirectory, _fileDirectoryPath, txtFilePath));

		text = _preprocessor.Process(text);
		 
		request.Content = new StringContent(text);

		var client = _clientFactory.CreateClient();

		var response = await client.SendAsync(request);
		ResponseDto[] result;

		if (!response.IsSuccessStatusCode)
		{
			throw new InvalidOperationException("Ошибка сервиса извлечения");
		}
		try
		{
			using var responseStream = await response.Content.ReadAsStreamAsync();
			//StreamReader reader = new StreamReader(responseStream); 
			//var responseText = reader.ReadToEnd();
			result = await JsonSerializer.DeserializeAsync<ResponseDto[]>(responseStream);
			var convertedResult = _responseConverter.Convert(result, documentId);
			await SaveResultAsync(convertedResult);
			var document = await _contactExtractorContext.Documents.SingleAsync(d => d.Id == documentId);
			document.Processed = true;
		}
		catch(Exception e)
		{
			throw new InvalidOperationException("Ошибка при обработке результата извлечения: " + e.Message);
		}
	}

	private async Task SaveResultAsync(ResultEntity resultEntity)
	{
		_contactExtractorContext.Results.Add(resultEntity);
		await _contactExtractorContext.SaveChangesAsync();
	}
}