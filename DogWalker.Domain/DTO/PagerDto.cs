namespace DogWalker.Domain.DTO;

public class PagerDto<TData>
{
    public PagerDto( IReadOnlyCollection<TData> elements)
    {
        Elements = elements;
    }

    public IReadOnlyCollection<TData> Elements { get; }

}