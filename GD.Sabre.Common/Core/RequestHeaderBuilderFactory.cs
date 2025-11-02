using GD.Sabre.Common.Core;
using GD.Sabre.Common.Core.Models.Options;
using Microsoft.Extensions.Options;

namespace GD.Sabre.Common.Core.Factories;

public class RequestHeaderBuilderFactory(IOptions<SabreServicesOptions> options) : IRequestHeaderBuilderFactory
{
    private readonly IOptions<SabreServicesOptions> _options = options ??
                                             throw new ArgumentNullException(nameof(options));

    public IRequestHeaderBuilder Create()
    {
        return new RequestHeaderBuilder(_options);
    }
}