using Soulgram.Gateway.Domain;

namespace Soulgram.Getway.IntegrationClients.Ports;

public interface IAccountManageClient
{
    Task<PageResponseBase<string>> GetUserMatesIds(
        UserIdPageRequest request,
        CancellationToken cancellationToken);
}