namespace Winston.Common
{
    public interface IPagedResponse<T> : IResponse<T>
    {
        Pagination Pagination { get; set; }
    }
}
