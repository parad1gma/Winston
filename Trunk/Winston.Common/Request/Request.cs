namespace Winston.Common
{
    public class Request<T> : IRequest<T>
    {
        public T Value { get; set; }

        public Page Page { get; set; }


    }
}
