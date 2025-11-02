using GD.Sabre.Common.Core;
using GD.Sabre.Common.Core.Factories;
using GD.Sabre.Common.Core.Models.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Sabre.Common.Service.SabreCommand;

public class SabreCommand(
        IOptions<SabreServicesOptions> options,
        ISoapServiceFactory soapServiceFactory,
        IRequestHeaderBuilderFactory requestHeaderBuilderFactory) : SabreService(options, soapServiceFactory), ISabreCommand
{
    private readonly IOptions<SabreServicesOptions> _options =
     options ?? throw new ArgumentNullException(nameof(options));

    private readonly IRequestHeaderBuilderFactory _requestHeaderBuilderFactory = requestHeaderBuilderFactory ?? throw new ArgumentNullException();

    public SabreCommandLLSRQRequestOutput ToSabre(SabreCommandOutput output)  => (SabreCommandLLSRQRequestOutput)((int)output);

    public async Task<SabreCommandResponse> Command(string cmd, string token, SabreCommandOutput output = SabreCommandOutput.SCREEN)
    {
        var response = await Command(cmd, token, ToSabre(output));

        if (response is null)
            return new SabreCommandResponse(500, "Null response", null);

        var hostCommand = response.HostCommand;
        var success = response.ApplicationResults?.Success != null;
        var status = response.ApplicationResults?.status;

        if (!success)
        {
            var ret = new SabreCommandResponse(100, "Command Failed", status);
            ret.HostCommand = cmd;
            return ret;
        }

        return new SabreCommandResponse(response?.Response ?? string.Empty, hostCommand, output, status);

    }

    public async Task<SabreCommandLLSRS?> Command(string cmd, string token, SabreCommandLLSRQRequestOutput output = SabreCommandLLSRQRequestOutput.SCREEN)
    {
        try
        {
            var requestHeaders = _requestHeaderBuilderFactory.Create()
                      .WithBasicAuth(_options?.Organization() ?? throw new ArgumentException("Organization not supplied"))
                      .WithAction("SabreCommandLLSRQ")
                      .WithService("SabreCommand")
                      .WithToken(token)
                      .WithConversationId(Guid.NewGuid().ToString())
                      .WithCPAId(_options?.Organization() ?? throw new ArgumentException("Organization not supplied"))
                      .WithMessageId(Guid.NewGuid().ToString())
                      .Build();


            var requestBody = new SabreCommandLLSRQ
            {
                ReturnHostCommand = true,

                Request = new SabreCommandLLSRQRequest
                {
                    HostCommand = ConvertCommand(cmd),
                    Output = output
                },

                Version = "2.0.0"

            };

            var _soapService = CreateSabreSoapService()
                  .WithHeaders(requestHeaders)
                  .WithPayload(requestBody);

            var openSessionResponseBody = await _soapService.PostAsync<SabreCommandLLSRS>();
            return openSessionResponseBody;

        }
        catch (Exception ex)
        {
            return null;
        }

    }

    private string ConvertCommand(string cmd)
    {
        if (cmd.Contains("‡"))
        {
            cmd = cmd.Replace("‡", "Â");
        }
        if (cmd.Contains("¥"))
        {
            cmd = cmd.Replace("¥", "Â");
        }

        return cmd;
    }

}
