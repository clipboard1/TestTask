﻿using TestTask.Application.Abstractions;
using TestTask.Infrastructure.Abstractions;
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
        int pageSize = 10, DateTime? dateFrom = null,
        DateTime? dateTo = null)
    {
        var result = await _repository.GetLogs(
            cancellationToken,
            page, pageSize,
            dateFrom, dateTo);

        return result;
    }
}