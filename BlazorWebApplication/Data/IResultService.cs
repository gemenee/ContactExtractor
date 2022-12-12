using PersonContactExtractor.Persistance;

namespace BlazorWebApplication
{
    public interface IResultService
    {
        public IEnumerable<ResultEntity> GetResults();

        public Task<ResultEntity> GetResultAsync(int documentId);
    }
}