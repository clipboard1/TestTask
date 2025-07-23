namespace TestTask.Infrastructure.Entities.LogEntity;

public enum LogRecordType
{
    Create = 0,
    Update = 1,
    Delete = 2,
    SystemError = 3,
    SystemWarning = 4,
    SystemInfo = 5
}