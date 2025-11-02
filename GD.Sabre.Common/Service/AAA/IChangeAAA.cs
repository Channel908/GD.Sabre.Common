namespace GD.Sabre.Common.Service.AAA;

public interface IChangeAAA
{
    Task<ChangeAAARS?> AAA(string PCC, string token);
    Task<ChangeAAAResponse> ChangePCC(string PCC, string token);
}
