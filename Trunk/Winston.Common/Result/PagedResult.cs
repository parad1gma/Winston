namespace Winston.Common
{
    public class PagedResult<T> : Result<T>, IPagedResult<T>
    {

        public IPage Page { get; set; }

        public int TotalCount { get; set; }

    }
}
