namespace GD.Sabre.Common.Core.Models;

public abstract class ResponseBase
{
    public ErrorResults? Errors { get; internal set; } = null;

    public bool Success => Errors is null || Errors.Count == 0;
    public string? Status { get; set; } = string.Empty;

    public Error AddError(int code, string message, Exception? ex = null)
    {
        Errors ??= new ErrorResults();
        return Errors.Add(code, message, ex);
    }
}

public sealed class ErrorResults
{
    private readonly List<Error> _errors = new();
    public int Count => _errors.Count;
    public IReadOnlyList<Error> Items => _errors;

    public Error Add(int code, string message, Exception? ex = null)
    {
        var error = new Error(code, message, ex);
        _errors.Add(error);
        return error;
    }

    public void Clear() => _errors.Clear();
}

public readonly record struct Error(int Code, string Message, Exception? Exception);