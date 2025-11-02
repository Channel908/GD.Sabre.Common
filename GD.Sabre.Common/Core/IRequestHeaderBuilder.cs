namespace GD.Sabre.Common.Core;
public interface IRequestHeaderBuilder
{
    IRequestHeaderBuilder WithBasicAuth(string Organization);
    IRequestHeaderBuilder WithSabreAth(string sabreAth);
    IRequestHeaderBuilder WithToken(string binarySecurityToken);
    IRequestHeaderBuilder WithAction(string action);
    IRequestHeaderBuilder WithCPAId(string cpaId);
    IRequestHeaderBuilder WithConversationId(string conversationId);
    IRequestHeaderBuilder WithMessageId(string messageId);
    IRequestHeaderBuilder WithService(string service);
    object[] Build();
}