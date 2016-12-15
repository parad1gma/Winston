namespace Winston.Common
{
    public interface IRequest<T>
    {

        Page Page { get; set; }
        T Value { get; set; }
    }
}
