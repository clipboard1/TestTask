using TestTask.Infrastructure.Models;

namespace TestTask.Api.Contracts;

public record LogResponse(
    int Id,
    string User,
    DateTime DateTime,
    string RecordType,
    string? Comment,
    Guid? LogGuid,
    Guid? LogGuidLinked,
    string? Entity,
    string? EventInfo,
    string? FieldName,
    string? OldValue,
    string? NewValue
)
{
    public static LogResponse FromEntity(Log log) =>
        new(
            log.Id,
            log.User,
            log.Datetime,
            Enum.GetName(log.Recordtype) ?? "Bad data",
            log.Comment,
            log.Logguid,
            log.Logguidlinked,
            log.Entity.HasValue ? Enum.GetName(log.Entity.Value) : "No info",
            log.Eventinfo.HasValue ? Enum.GetName(log.Eventinfo.Value) : "No info",
            log.Fieldname,
            log.Oldvalue,
            log.Newvalue
        );
}
