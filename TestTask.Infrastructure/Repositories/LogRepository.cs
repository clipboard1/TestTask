using Microsoft.EntityFrameworkCore;
using TestTask.Infrastructure.Abstractions;
using TestTask.Infrastructure.Models;

namespace TestTask.Infrastructure.Repositories;

public class LogRepository : ILogRepository
{
    private readonly TestTaskDbContext _context;

    public LogRepository(TestTaskDbContext context)
    {
        _context = context;
    }

    public async Task<(List<Log>, int TotalCount)> GetLogs(CancellationToken cancellationToken, int page = 1,
        int pageSize = 10,
        DateTime? dateFrom = null, DateTime? dateTo = null)
    {
        if (page < 1)
            return ([], 0);
        if (pageSize < 1)
            return ([], 0);

        var query = _context.Logs.AsQueryable();

        if (dateFrom.HasValue)
            query = query.Where(l => l.Datetime >= dateFrom);
        
        if (dateTo.HasValue)
            query = query.Where(l => l.Datetime <= dateTo);

        var totalCount = await query.CountAsync(cancellationToken);

        var taskEntities = await query
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (taskEntities, totalCount);
    }
}