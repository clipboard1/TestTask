using TestTask.Infrastructure.Entities.LogEntity;
using TestTask.Infrastructure.Models;

namespace TestTask.Infrastructure.Abstractions;

public interface ILogRepository
{
    public Task<(List<Log>, int TotalCount)> GetLogs(CancellationToken cancellationToken,
        int page = 1,
        int pageSize = 10,
        DateTime? date = null,
        LogEntityType? entityType = null,
        string? user = null);
}