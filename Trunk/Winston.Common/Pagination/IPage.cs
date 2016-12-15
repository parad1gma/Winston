namespace Winston.Common
{
    public interface IPage
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }

        int Skip { get; }
    }
}
