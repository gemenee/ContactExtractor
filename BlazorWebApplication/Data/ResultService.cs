using Microsoft.EntityFrameworkCore;
using PersonContactExtractor.Persistance;

namespace BlazorWebApplication
{
    public class ResultService : IResultService
    {
        private ContactExtractorContext _db;

        public ResultService(ContactExtractorContext db)
        {
            _db = db;
        }

        public IEnumerable<ResultEntity> GetResults()
        {
            return _db.Results;
        }

        public async Task<ResultEntity> GetResultAsync(int documentId)
        {
            return await _db.Results.SingleAsync(r => r.DocumentId == documentId); ;
        }
    }
}