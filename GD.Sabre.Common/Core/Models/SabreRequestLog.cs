namespace GD.Sabre.Common.Core.Models;


public class SabreRequestLog(
    DateTime utcDateTime,
    bool success,
    string? request,
    string? response,
    string? exception,
    string? externalId)
{
    public DateTime UtcDateTime { get; } = utcDateTime;

    public bool Success { get; } = success;

    public string? Request { get; } = request;

    public string? Response { get; } = response;

    public string? Exception { get; } = exception;

    public string? ExternalId { get; } = externalId;
}