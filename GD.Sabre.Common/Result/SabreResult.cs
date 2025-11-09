using GD.Sabre.Common.Service.Session;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GD.Sabre.Common;

public sealed class SabreResult<T>
{

    private SabreResult(T value)
    {
        Response = value;
        IsSuccess = true;
    }

    private SabreResult(SabreError? error)
    {
        Error = error ?? SabreError.CreateUnknowError();
        IsSuccess = false;
    }

    private SabreResult(string error)
    {
        IsSuccess = false;

        Error = new SabreError
        {
            Errors = [error]
        };

    }

    private SabreResult(object? error)
    {
        IsSuccess = false;
        Error = error;
    }

    private SabreResult(Exception error)
    {
        IsSuccess = false;


        var ex = Debugger.IsAttached
            ? error
            : null;

        Error = new SabreError
        {
            Exception = ex,
            Errors = [ex?.Message ?? SabreError._sabre_result_internal_server_error]
        };

    }

    public bool IsSuccess { get; }
    public object? Error { get;}
    public T? Response { get; }

    public static SabreResult<T> Success(T value) => new(value);
    public static SabreResult<T> Failure(SabreError? error) => new(error);
    public static SabreResult<T> Failure(string error) => new(error);
    public static SabreResult<T> Failure(Exception error) => new(error);
    public static SabreResult<T> Failure(object? error) => new(error);

}

public class SabreError
{
    internal readonly static string _sabre_result_internal_server_error = "Sabre Result Internal Server Error";

    public SabreError()
    {
        
    }

    public Exception? Exception { get; set; }
    public IEnumerable<string> Errors { get; set; } = [];



    public static SabreError CreateUnknowError()
    {
        return new SabreError
        {
            Errors = [_sabre_result_internal_server_error]
        };
    }
}
