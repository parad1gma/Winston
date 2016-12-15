namespace Winston.Common
{
    public class PagedResponse<T> : Response<T>, IPagedResponse<T>
    {
        public Pagination Pagination { get; set; }
    }
}
