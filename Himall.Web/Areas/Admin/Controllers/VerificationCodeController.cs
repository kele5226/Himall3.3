using Himall.Application;
using Himall.CommonModel;
using Himall.Core;
using Himall.DTO;
using Himall.DTO.QueryModel;
using Himall.Web.Areas.Admin.Models;
using Himall.Web.Framework;
using Himall.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Himall.Web.Areas.Admin.Controllers
{
    public class VerificationCodeController : BaseAdminController
    {
        // GET: SellerAdmin/VerificationCode
        public ActionResult Management()
        {
            bool isOpenStore = SiteSettingApplication.SiteSettings != null && SiteSettingApplication.SiteSettings.IsOpenStore;
            ViewBag.IsOpenStore = isOpenStore;
            return View();
        }

        [HttpPost]
        public JsonResult List(VerificationRecordQuery query, int page, int rows)
        {
            query.PageNo = page;
            query.PageSize = rows;
            var orderVerificationCode = OrderApplication.GetOrderVerificationCodeInfos(query);
            DataGridModel<OrderVerificationCodeModel> dataGrid = new DataGridModel<OrderVerificationCodeModel>() { rows = orderVerificationCode.Models, total = orderVerificationCode.Total };
            return Json(dataGrid);
        }

        public JsonResult GetShopAndShopBranch(string keyWords)
        {
            var result = OrderApplication.GetShopOrShopBranch(keyWords);
            var values = result.Select(item => new { type = item.Type, value = item.Name, id = item.SearchId });
            return Json(values);
        }
    }
}