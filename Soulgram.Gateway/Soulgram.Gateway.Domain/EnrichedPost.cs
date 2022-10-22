namespace Soulgram.Gateway.Domain;

public record EnrichedPost : Post
{
    public string Id { get; init; }
    public DateTime CreationDate { get; init; }
    public bool Liked { get; init; }
    public PostMetadata Metadata { get; set; }
    public IEnumerable<string> Medias { get; set; }
}