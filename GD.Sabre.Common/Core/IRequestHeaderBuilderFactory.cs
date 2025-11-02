using GD.Sabre.Common.Core;

namespace GD.Sabre.Common.Core.Factories;

public interface IRequestHeaderBuilderFactory
{
    IRequestHeaderBuilder Create();
}
