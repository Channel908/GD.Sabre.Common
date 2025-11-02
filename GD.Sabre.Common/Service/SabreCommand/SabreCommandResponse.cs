using GD.Sabre.Common.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GD.Sabre.Common.Service.SabreCommand;

public class SabreCommandResponse : ResponseBase
{

    public SabreCommandResponse() { }

    public SabreCommandResponse(string results, string hostCommand, SabreCommandOutput output, string? status)
    {
        Results = results;
        Output = output;
        Status = status;
        HostCommand = hostCommand;
    }

    public SabreCommandResponse(int errorCode, string message, string? status, Exception? ex = null)
    {
        AddError(errorCode, message, ex);
        Status = status;
    }


    public string? Results { get; internal set; } = string.Empty;
    public string? HostCommand { get; internal set; } = string.Empty;


    public SabreCommandOutput Output { get; internal set; }

}

public enum SabreCommandOutput
{

    /// <remarks/>
    SCREEN,

    /// <remarks/>
    SDS,

    /// <remarks/>
    SDSXML,

    /// <remarks/>
    DATABAHN,

    /// <remarks/>
    JSON
}

