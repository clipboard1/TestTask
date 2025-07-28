using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestTask.Api.Contracts;
using TestTask.Application.Abstractions;
using TestTask.Application.Services;
using TestTask.Infrastructure.Entities.LogEntity;
using TestTask.Infrastructure.Models;

namespace TestTask.Api.Controllers;

public class LogController: Controller
{
    private readonly ILogService _service;

    public LogController(ILogService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Get(
        CancellationToken cancellationToken, int page = 1,
        int pageSize = 20, DateTime? dateFrom = null,
        DateTime? dateTo = null,
        string? entityType = null,
        string? user = null)

    {
        var result = await _service.GetLogs(
            cancellationToken,
            page, pageSize,
            dateFrom, dateTo,
            entityType, user);

        if (!result.logs.Any())
            return NotFound();

        var logs = result.logs
            .Select(LogResponse.FromEntity);

        return Ok(new { logs, result.TotalCount });
    }
}