namespace Winston.Common
{
    public interface IPagedResult<T> : IResult<T>
    {
        IPage Page { get; set; }

        int TotalCount { get; set; }
    }
}
