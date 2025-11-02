using GD.Sabre.Common.Core.Models;

namespace GD.Sabre.Common.Core;

public interface ISabreService
{
    void WithLoggingStrategy(SabreRequestLoggingStrategy loggingStrategy);

}