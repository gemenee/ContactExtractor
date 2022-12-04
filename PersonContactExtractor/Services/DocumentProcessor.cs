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

    public async Task<TestDto> ProcessDocumentAsync(int documentId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post,
            "http://localhost:8000/extract");
        request.Content = new StringContent("hello from HTTP POST");

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        TestDto result = new TestDto();

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            result = await JsonSerializer.DeserializeAsync<TestDto>(responseStream);
        }

        return result;
    }
}