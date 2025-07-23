using TestTask.Infrastructure.Models;

namespace TestTask.Infrastructure.Abstractions;

public interface ILogRepository
{
    public Task<(List<Log>, int TotalCount)> GetLogs(CancellationToken cancellationToken,
        int page = 1,
        int pageSize = 10,
        DateTime? dateFrom = null,
        DateTime? dateTo = null);
}