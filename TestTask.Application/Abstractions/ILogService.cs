using TestTask.Infrastructure.Entities.LogEntity;
using TestTask.Infrastructure.Models;

namespace TestTask.Application.Abstractions;

public interface ILogService
{
    public Task<(List<Log> logs, int TotalCount)> GetLogs(CancellationToken cancellationToken,
        int page = 1,
        int pageSize = 10,
        DateTime? date = null,
        string? entityType = null,
        string? user = null);
}