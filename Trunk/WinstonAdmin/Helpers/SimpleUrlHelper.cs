using System.Web.Mvc;

namespace Winston.Admin.Helpers
{
    public class SimpleUrlHelper
    {
        public static string UrlObjectToRoot(UrlHelper Url)
        {
            string getLeftPart = Url.Action("a", "b");
            getLeftPart = getLeftPart.Substring(0, (getLeftPart.Length - "/b/a".Length));
            return getLeftPart;
        }

        public static string HtmlHelperToRoot(HtmlHelper helper)
        {
            return UrlObjectToRoot(new UrlHelper(helper.ViewContext.RequestContext));
        }
    }
}