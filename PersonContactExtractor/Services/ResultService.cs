using Microsoft.EntityFrameworkCore;
using PersonContactExtractor.Persistance;

namespace PersonContactExtractor.Services;

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

        return await _db.Results
            .Include(r => r.Persons)
            .ThenInclude(p => p.Organization)
            .SingleAsync(r => r.DocumentId == documentId);

    }
}