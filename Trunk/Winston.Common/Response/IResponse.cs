namespace Winston.Common
{
    public interface IResponse<T> : IResult<T>
    {
        string Message { get; set; }

    }
}
