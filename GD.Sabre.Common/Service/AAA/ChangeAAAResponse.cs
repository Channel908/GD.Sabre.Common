using GD.Sabre.Common.Core.Models;
using System.Net.NetworkInformation;

namespace GD.Sabre.Common.Service.AAA;

public class ChangeAAAResponse : ResponseBase
{
    public ChangeAAAResponse() { }

    public ChangeAAAResponse(int errorCode, string message, string? status, Exception? ex = null)
    {
        AddError(errorCode, message, ex);
        Status = status;
    }
}