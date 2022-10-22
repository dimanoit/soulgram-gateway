namespace Soulgram.Gateway.Domain;

public abstract record PageResponseBase<T>
{
    public IEnumerable<T> Data { get; set; }
    public int TotalCount { get; set; }
}