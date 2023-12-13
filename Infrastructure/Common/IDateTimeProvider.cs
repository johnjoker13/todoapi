namespace Infrastructure.Common;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}