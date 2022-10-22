namespace Soulgram.Gateway.Domain;

public record PostsByUserIdRequest : PageRequestBase
{
    public string[] UsersIds { get; set; }
    public string CurrentUserId { get; set; }
}