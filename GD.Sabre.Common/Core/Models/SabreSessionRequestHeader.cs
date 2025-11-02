using GD.Sabre.Common.Core;

namespace GD.Sabre.Common.Core.Models;

public class SabreSessionRequestHeader(IRequestHeaderBuilder requestHeaderBuilder) : IDisposable
{
    public string SecurityToken { get; set; } = string.Empty;
    public IRequestHeaderBuilder RequestHeaderBuilder = requestHeaderBuilder;
    public event EventHandler? SessionDisposed;

    public void Dispose()
    {
        SessionDisposed?.Invoke(this, EventArgs.Empty);
    }
}
