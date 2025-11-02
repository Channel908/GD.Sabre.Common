using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Sabre.Common.Service.SabreCommand;

public interface ISabreCommand
{
    Task<SabreCommandLLSRS?> Command(string cmd, string token, SabreCommandLLSRQRequestOutput output = SabreCommandLLSRQRequestOutput.SCREEN);
    Task<SabreCommandResponse> Command(string cmd, string token, SabreCommandOutput output = SabreCommandOutput.SCREEN);

}
