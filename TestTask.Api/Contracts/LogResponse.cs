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
    );