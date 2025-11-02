using System.Text;

namespace GD.Sabre.Common.Core;

public static class ExceptionExtensions
{
    /// <summary>
    /// Returns the chain of inner exceptions for a given exception
    /// </summary>
    /// <param name="exception">The source exception</param>
    /// <returns></returns>
    public static IEnumerable<Exception> GetInnerExceptionsChain(this Exception exception)
    {
        var nextException = exception.InnerException;

        while (nextException != null)
        {
            yield return nextException;
            nextException = nextException.InnerException;
        }
    }

    /// <summary>
    /// Returns the message for a given exception and all those in the inner exception chain as a delimited string
    /// </summary>
    /// <param name="exception">The source exception</param>
    /// <param name="delimiter">The delimiter to use between each exception in the chain</param>
    /// <returns></returns>
    public static string GetCombinedExceptionMessages(
        this Exception exception,
        string delimiter = "|")
    {
        var exceptionMessageBuilder = new StringBuilder(exception.Message);

        exception.GetInnerExceptionsChain().ToList().ForEach(innerException =>
            exceptionMessageBuilder.Append($" {delimiter.Trim()} {innerException.Message}"));

        return exceptionMessageBuilder.ToString();
    }
}


public class SabreException: Exception
{
    public SabreException()
    {
        
    }

    public SabreException(string message) : base(message) 
    {
        
    }

}

public class SoapServiceException : Exception
{
    public SoapServiceException()
    {
    }

    public SoapServiceException(string message)
        : base(message)
    {
    }

    public SoapServiceException(string message, string? request, string? response)
        : base(message)
    {
        Request = request;
        Response = response;
    }

    public SoapServiceException(string message, Exception inner)
        : base(message, inner)
    {
    }

    public SoapServiceException(string message, Exception inner, string? request, string? response)
        : base(message, inner)
    {
        Request = request;
        Response = response;
    }

    public string? Request { get; }

    public string? Response { get; }
}


public class GalServiceException : Exception
{
    public GalServiceException()
    {
    }

    public GalServiceException(string message)
        : base(message)
    {
    }

    public GalServiceException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
