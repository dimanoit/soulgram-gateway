namespace Soulgram.Gateway.Domain;

public record PostMetadata
{
    public int Views { get; set; }
    public int Likes { get; set; }
    public int Comments { get; set; }
}