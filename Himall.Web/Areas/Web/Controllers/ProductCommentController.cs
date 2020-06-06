using Himall.Application;
using Himall.IServices;
using Himall.Web.Framework;
using System.Linq;
using System.Web.Mvc;

namespace Himall.Web.Areas.Web.Controllers
{
    public class ProductCommentController : BaseController
    {
       private ICommentService _iCommentService;
       private IProductService _iProductService;
        public ProductCommentController(ICommentService iCommentService, IProductService iProductService)
       {
           _iCommentService = iCommentService;
           _iProductService = iProductService;

        }

        // GET: Web/ProductComment
        public ActionResult Index(long id)
        {
            var productMark = CommentApplication.GetProductAverageMark(id);
            ViewBag.CommentCount = CommentApplication.GetCommentCountByProduct(id);
            ViewBag.productMark = productMark;
            var productinfo = _iProductService.GetProduct(id);
            ViewBag.Keyword = SiteSettings.Keyword;
            return View(productinfo);
        }



    }
}