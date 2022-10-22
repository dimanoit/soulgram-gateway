namespace Soulgram.Gateway.Domain;

public record CompactUserInfoResponse
{
    public string? Id { get; init; }
    public string? ImgUrl { get; init; }
    public string? Nickname { get; init; }
    public string? Fullname { get; init; }
}