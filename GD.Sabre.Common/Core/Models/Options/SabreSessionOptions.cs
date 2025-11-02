namespace GD.Sabre.Common.Core.Models.Options;

public class SabreSessionOptions
{
    public bool UseSessionPool { get; set; } = true;
    public int SessionTimeout { get; set; } = 20;
    public int MaxAliveSessionsInPool_PerPCC { get; set; } = 10;
    public int MaxSimultaneousRequest_PerSession { get; set; } = 5;
    public int MaxRetries { get; set; } = 5;
    public string SessionDb { get; set; } = string.Empty;
}
