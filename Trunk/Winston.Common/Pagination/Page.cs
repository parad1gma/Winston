namespace Winston.Common
{
    public class Page : IPage
    {
        public Page()
        {

        }
        public Page(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int Skip
        {
            get
            {
                return (PageNumber - 1) * PageSize;
            }
        }
    }
}
