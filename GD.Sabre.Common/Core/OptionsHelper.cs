using GD.Sabre.Common.Core.Models.Options;
using Microsoft.Extensions.Options;

namespace GD.Sabre.Common.Core;

public static class OptionsHelper
{
    public static int? MaxAliveSessionsInPool_PerPCC(this IOptions<SabreServicesOptions>? options)
        => options?.Value?.Sessions?.MaxAliveSessionsInPool_PerPCC;
    public static int? MaxRetries(this IOptions<SabreServicesOptions>? options)
      => options?.Value?.Sessions?.MaxRetries;

    public static int? MaxSimultaneousRequest_PerSession(this IOptions<SabreServicesOptions>? options)
    => options?.Value?.Sessions?.MaxSimultaneousRequest_PerSession;

    public static int? SessionTimeout(this IOptions<SabreServicesOptions>? options)
    => options?.Value?.Sessions?.SessionTimeout;

    public static bool? UseSessionPool(this IOptions<SabreServicesOptions>? options)
    => options?.Value?.Sessions?.UseSessionPool;

    public static string? UserName(this IOptions<SabreServicesOptions>? options)
    => options?.Value?.XmlProfileServiceApi?.UserName;

    public static string? Password(this IOptions<SabreServicesOptions>? options)
    => options?.Value?.XmlProfileServiceApi?.Password;

    public static string? BaseUri(this IOptions<SabreServicesOptions>? options)
    => options?.Value?.XmlProfileServiceApi?.BaseUri;

    public static string? ServiceUri(this IOptions<SabreServicesOptions>? options)
    => options?.Value?.XmlProfileServiceApi?.ServiceUri;

    public static string? Organization(this IOptions<SabreServicesOptions>? options)
    => options?.Value?.XmlProfileServiceApi?.Organization;

}
