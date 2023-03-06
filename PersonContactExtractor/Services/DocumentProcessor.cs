using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PersonContactExtractor.Persistance;
using WebApplication.Dto;

namespace PersonContactExtractor.Services;

public class DocumentProcessor : IDocumentProcessor
{
	private readonly string _fileDirectoryPath = Path.Combine("unsafe_uploads", "plain_text");
	private readonly IHttpClientFactory _clientFactory;
	private readonly ContactExtractorContext _contactExtractorContext;
	private readonly ITextPreprocessor _preprocessor;

	public DocumentProcessor(
		IHttpClientFactory clientFactory,
		ContactExtractorContext contactExtractorContext,
		ITextPreprocessor textPreprocessor)
	{
		_clientFactory = clientFactory;
		_contactExtractorContext = contactExtractorContext;
		_preprocessor = textPreprocessor;
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
			result = await JsonSerializer.DeserializeAsync<ResponseDto[]>(responseStream);
			var convertedResult = await Convert(result, documentId);
			await SaveResultAsync(convertedResult);
		}
		catch
		{
			throw new InvalidOperationException("Ошибка при обработке результата извлечения");
		}
	}

	private async Task<ResultEntity> Convert(ResponseDto[] responses, int documentId)
	{
		var result = new ResultEntity
		{
			Persons = new System.Collections.Generic.List<PersonContacts>(),
			DocumentId = documentId
		};
		foreach (var response in responses)
		{
			result.Persons.Add(new PersonContacts
			{
				FirstName = response.NameDto.First,
				MiddleName = response.NameDto.Middle,
				LastName = response.NameDto.Last,
				Phone = response.Contacts.Phone,
				Email = response.Contacts.Email,

				Organization = response.Organization is not null ? new OrganizationEntity
				{
					Name = response.Organization.OrgName,
					Subdivision = response.Organization.UnitDto.ToString()
				} : null,
				Position = response.Position?.ToString()
			});
		}

		var document = await _contactExtractorContext.Documents.SingleAsync(d => d.Id == documentId);
		document.Processed = true;

		return result;
	}

	private async Task SaveResultAsync(ResultEntity resultEntity)
	{
		_contactExtractorContext.Results.Add(resultEntity);
		await _contactExtractorContext.SaveChangesAsync();
	}
}