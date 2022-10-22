namespace Soulgram.Gateway.Domain;

public record UserIdPageRequest : PageRequestBase
{
    public string UserId { get; init; } = null!;
}