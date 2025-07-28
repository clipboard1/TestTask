using TestTask.Application.Abstractions;
using TestTask.Infrastructure.Abstractions;
using TestTask.Infrastructure.Entities.LogEntity;
using TestTask.Infrastructure.Models;
using TestTask.Infrastructure.Repositories;

namespace TestTask.Application.Services;

public class LogService : ILogService
{
    private readonly ILogRepository _repository;

    public LogService(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<(List<Log> logs, int TotalCount)> GetLogs(
        CancellationToken cancellationToken, int page = 1,
        int pageSize = 10, DateTime? date = null,
        string? entityType = null, string? user = null)

    {
        var entityFilter = Enum.TryParse<LogEntityType>(entityType, true, out var parsedEntity)
            ? parsedEntity
            : (LogEntityType?)null;


        var result = await _repository.GetLogs(
            cancellationToken,
            page, pageSize,
            date, entityFilter,
            user);
        return result;
    }
}