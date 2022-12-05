using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PersonContactExtractor.Persistance;

namespace PersonContactExtractor;

public class DocumentProcessor : IDocumentProcessor
{
    private readonly IHttpClientFactory _clientFactory;

    public DocumentProcessor(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<ResponseDto[]> ProcessDocumentAsync(int documentId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post,
            "http://localhost:5000/extract");
        request.Content = new StringContent("Заместитель начальника организационно-экономического отдела управления Пенсионного фонда Иван Семенович Гостюхин (+71234567890, i.s.gostiuhin@gmail.com). Оперативный сотрудник 3 отдела полиции Злыбин О.П. (89876543210). Преподаватель Пензенского государственного университета Замутин Георгий Сергеевич (+71029384756). Антонов Григорий Васильевич (+71134567890, gvantonov@mail.ru)");

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        ResponseDto[] result;

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            result = await JsonSerializer.DeserializeAsync<ResponseDto[]>(responseStream);
        }

        return Array.Empty<ResponseDto>();
    }
}