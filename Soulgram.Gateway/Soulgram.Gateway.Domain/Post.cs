namespace Soulgram.Gateway.Domain;

public record Post
{
    public string UserId { get; init; }
    public string Text { get; init; }

    public IEnumerable<string> Hashtags { get; set; }
}