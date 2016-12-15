namespace Winston.Common
{
    public interface IResult<T>
    {
        Status Status { get; set; }

        T Value { get; set; }
    }
}
