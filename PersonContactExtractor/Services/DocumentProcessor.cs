using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonContactExtractor.Persistance;

namespace PersonContactExtractor;

public class DocumentProcessor : IDocumentProcessor
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ContactExtractorContext _contactExtractorContext;

    public DocumentProcessor(IHttpClientFactory clientFactory, ContactExtractorContext contactExtractorContext)
    {
        _clientFactory = clientFactory;
        _contactExtractorContext = contactExtractorContext;
    }

    public async Task ProcessDocumentAsync(int documentId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post,
            "http://localhost:5000/extract");
        request.Content = new StringContent("Заместитель начальника организационно-экономического отдела управления Пенсионного фонда Иван Семенович Гостюхин (+71234567890, i.s.gostiuhin@gmail.com). Оперативный сотрудник 3 отдела полиции Злыбин О.П. (89876543210). Преподаватель Пензенского государственного университета Замутин Георгий Сергеевич (+71029384756). Антонов Григорий Васильевич (+71134567890, gvantonov@mail.ru)");

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