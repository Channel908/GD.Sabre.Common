using GD.Sabre.Common.Core;
using GD.Sabre.Common.Core.Factories;
using GD.Sabre.Common.Core.Models;
using GD.Sabre.Common.Core.Models.Options;
using GD.Sabre.Common.Core.Reference;
using Microsoft.Extensions.Options;

namespace GD.Sabre.Common.Service.AAA;

public class ChangeAAA(
        IOptions<SabreServicesOptions> options,
        ISoapServiceFactory soapServiceFactory,
        IRequestHeaderBuilderFactory requestHeaderBuilderFactory) : SabreService(options, soapServiceFactory), IChangeAAA
{

    private readonly IOptions<SabreServicesOptions> _options =
       options ?? throw new ArgumentNullException(nameof(options));

    private readonly IRequestHeaderBuilderFactory _requestHeaderBuilderFactory = requestHeaderBuilderFactory ??
        throw new ArgumentNullException();

    public async Task<ChangeAAAResponse> ChangePCC(string PCC, string token)
    {
        var response = await AAA(PCC, token);

        if (response is null)
            return new ChangeAAAResponse(500, "Null response", null);

        return new ChangeAAAResponse();
    }

    public async Task<ChangeAAARS?> AAA(string PCC, string token)
    {
        try
        {
            var requestHeaders = _requestHeaderBuilderFactory.Create()
                  .WithBasicAuth(_options?.Organization() ?? throw new ArgumentException("Organization not supplied"))
                  .WithAction("ChangeAAALLSRQ")
                  .WithService("ChangeAAA")
                  .WithToken(token)
                  .WithConversationId(Guid.NewGuid().ToString())
                  .WithCPAId(_options?.Organization() ?? throw new ArgumentException("Organization not supplied"))
                  .WithMessageId(Guid.NewGuid().ToString())
                  .Build();

            var requestBody = new ChangeAAARQ
            {

                POS = new ChangeAAARQPOS
                {
                    Source = new ChangeAAARQPOSSource
                    {
                        PseudoCityCode = PCC,
                    }
                },
                AAA = new ChangeAAARQAAA
                {
                    PseudoCityCode = PCC
                },
                Version = "1.1.1"

            };

            var _soapService = CreateSabreSoapService()
                  .WithHeaders(requestHeaders)
                  .WithPayload(requestBody);

            var openSessionResponseBody = await _soapService.PostAsync<ChangeAAARS>();
            return openSessionResponseBody;
        }
        catch (Exception ex)
        {
            return null;
        }

    }
}