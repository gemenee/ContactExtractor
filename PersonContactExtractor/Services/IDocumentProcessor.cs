using System.Threading.Tasks;

namespace PersonContactExtractor;

public interface IDocumentProcessor
{
    Task ProcessDocumentAsync(int documentId);
}