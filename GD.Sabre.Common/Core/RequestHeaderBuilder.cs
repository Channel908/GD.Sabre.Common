using GD.Sabre.Common.Core.Models.Options;
using GD.Sabre.Common.Core.Reference;
using Microsoft.Extensions.Options;

namespace GD.Sabre.Common.Core;

public class RequestHeaderBuilder(IOptions<SabreServicesOptions> options) : IRequestHeaderBuilder
{
    private readonly IOptions<SabreServicesOptions> _options = options ?? throw new ArgumentNullException(nameof(options));

    private Security? _security = null;
    private string? _action = null;
    private string? _cpaId = null;
    private string? _conversationId = null;
    private string? _messageId = null;
    private string? _service = null;
    public IRequestHeaderBuilder WithBasicAuth(string Organization)
    {
        _security = new Security
        {
            UsernameToken = new SecurityUsernameToken()
            {
                Username = options.UserName() ?? throw new ArgumentNullException("credentials"),
                Password = options.Password() ?? throw new ArgumentNullException("credentials"),
                Domain = "DEFAULT",
                Organization = Organization
            }
        };
        return this;
    }

    public IRequestHeaderBuilder WithSabreAth(string sabreAth)
    {
        _security = new Security
        {
            SabreAth = sabreAth
        };
        return this;
    }

    public IRequestHeaderBuilder WithToken(string binarySecurityToken)
    {
        _security = new Security
        {
            BinarySecurityToken = binarySecurityToken
        };
        return this;
    }

    public IRequestHeaderBuilder WithAction(string action)
    {
        _action = action;
        return this;
    }

    public IRequestHeaderBuilder WithCPAId(string cpaId)
    {
        _cpaId = cpaId;
        return this;
    }

    public IRequestHeaderBuilder WithConversationId(string conversationId)
    {
        _conversationId = conversationId;
        return this;
    }

    public IRequestHeaderBuilder WithMessageId(string messageId)
    {
        _messageId = messageId;
        return this;
    }

    public IRequestHeaderBuilder WithService(string service)
    {
        _service = service;
        return this;
    }

    public object[] Build()
    {
        if (_security == null)
        {
            throw new InvalidOperationException("Security must be specified");
        }

        if (string.IsNullOrEmpty(_action))
        {
            throw new InvalidOperationException("Action must be specified");
        }

        if (string.IsNullOrEmpty(_messageId))
        {
            throw new InvalidOperationException("MessageId must be specified");
        }

        if (string.IsNullOrEmpty(_service))
        {
            throw new InvalidOperationException("Service must be specified");
        }

        MessageHeader messageHeader = new MessageHeader
        {
            Action = _action,
            CPAId = _cpaId,
            ConversationId = _conversationId,
            version = "1.0",
            Service = new Reference.Service()
            {
                Value = _service,
                type = "sabreXML"
            },
            From = new From()
            {
                PartyId = new PartyId[]{
                        new PartyId(){
                            Value = "WebServiceClient",
                        }
                    }
            },
            To = new To()
            {
                PartyId = new PartyId[]{
                        new PartyId(){
                            Value = "WebServiceSupplier",
                        }
                    }
            },
            MessageData = new MessageData()
            {
                Timestamp = DateTime.UtcNow.ToString("s") + "Z",
                TimeToLive = DateTime.UtcNow.AddMinutes(5).ToString(),
                TimeToLiveSpecified = true,
                MessageId = _messageId
            }

        };
        return new object[] { messageHeader, _security };
    }
}
