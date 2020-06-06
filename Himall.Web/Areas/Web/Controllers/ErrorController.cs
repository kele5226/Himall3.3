using Himall.Web.Framework;
using System.Web.Mvc;

namespace Himall.Web.Areas.Web.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: Web/Common
        public ActionResult Error404()
        {
            ViewBag.Keyword = SiteSettings.Keyword;
            return View();
        }

        public ActionResult DefaultError()
        {
            ViewBag.Keyword = SiteSettings.Keyword;
            return View();
        }
    }
}