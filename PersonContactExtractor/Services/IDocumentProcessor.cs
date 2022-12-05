using System.Threading.Tasks;
using PersonContactExtractor.Persistance;

namespace PersonContactExtractor;

public interface IDocumentProcessor
{
    Task<ResponseDto[]> ProcessDocumentAsync(int documentId);
}