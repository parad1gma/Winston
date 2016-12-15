namespace Winston.Common
{
    public class Response<T> : Result<T>, IResponse<T>
    {
        public string Message { get; set; }
    }
}
