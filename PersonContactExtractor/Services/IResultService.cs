
using PersonContactExtractor.Persistance;

namespace PersonContactExtractor.Services;
public interface IResultService
{
    public IEnumerable<ResultEntity> GetResults();

    public Task<ResultEntity> GetResultAsync(int documentId);
}