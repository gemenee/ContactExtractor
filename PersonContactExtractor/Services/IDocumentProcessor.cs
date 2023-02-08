using System.Threading.Tasks;

namespace PersonContactExtractor.Services;

public interface IDocumentProcessor
{
    Task ProcessDocumentAsync(int documentId);
}