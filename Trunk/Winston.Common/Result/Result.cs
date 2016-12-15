namespace Winston.Common
{
    public class Result<T> : IResult<T>
    {
        public T Value { get; set; }

        public Status Status { get; set; }
    }

    public class NoValue
    {
        private NoValue()
        {

        }
    }
}
