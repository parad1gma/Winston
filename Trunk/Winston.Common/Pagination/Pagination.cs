using System;
using System.Collections.Generic;

namespace Winston.Common
{
    public class Pagination : Page
    {
        public Pagination(IPage page, int totalCount) : base(page.PageNumber, page.PageSize)
        {
            TotalCount = totalCount;
            if (TotalCount == 0)
            {
                PageNumber = 0;
            }
        }


        public int TotalCount { get; set; }

        public int First
        {
            get
            {
                return PageNumber > 1 ? 1 : 0;
            }
        }

        public int Previous
        {
            get
            {
                return PageNumber > 1 ? PageNumber - 1 : 0;
            }
        }

        public int Next
        {
            get
            {
                return PageNumber < LastPage ? PageNumber + 1 : PageNumber;
            }
        }

        public int LastPage
        {
            get
            {
                return TotalCount % PageSize == 0 ? TotalCount / PageSize : TotalCount / PageSize + 1;
            }
        }

        public List<Item> PageSizeList
        {
            get
            {
                return GetPageSizes();
            }
        }

        public string PageInfo
        {
            get
            {
                return GetPageInfo();
            }
        }

        /// <summary>
        /// Read from settings (can be customized per user and/or per page), or returns default values
        /// </summary>
        /// <returns></returns>
        private List<Item> GetPageSizes()
        {
            return new List<Item>()
                {
                    new Item() {Id = 5, Value = "5"},
                    new Item() {Id = 10, Value = "10"},
                    new Item() {Id = 15, Value = "15"},
                    new Item() {Id = 20, Value = "20"},
                };
        }

        //Need tunning
        private string GetPageInfo()
        {
            int from;
            int to;

            if (TotalCount == 0)
            {
                from = 0;
                to = 0;
            }
            else
            {
                from = Previous == 0 ? 1 : ((PageNumber - 1) * PageSize) + 1;
                to = from + PageSize - 1 > TotalCount ? TotalCount : from + PageSize - 1;
            }

            return String.Format("Showing {0} - {1} of {2} items.", from, to, TotalCount);
        }

    }
}
