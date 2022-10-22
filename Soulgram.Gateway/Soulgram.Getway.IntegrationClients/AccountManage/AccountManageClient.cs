using Soulgram.Gateway.Domain;
using Soulgram.Getway.IntegrationClients.Ports;

namespace Soulgram.Getway.IntegrationClients.AccountManage;

internal class AccountManageClient : IAccountManageClient
{
    private readonly HttpClient _httpClient;

    public AccountManageClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PageResponseBase<string>> GetUserMatesIds(
        UserIdPageRequest request,
        CancellationToken cancellationToken)
    {
        var url = $"mate/{request.UserId}/ids?skip=${request.Skip}&take=${request.Take}";
        var result = await _httpClient.GetHttpResult<UserIdResponse>(url, cancellationToken);

        return result;
    }
}