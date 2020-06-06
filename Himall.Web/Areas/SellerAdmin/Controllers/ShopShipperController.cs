
using System.Web.Mvc;
using Himall.Core;
using Himall.CommonModel;
using Himall.DTO;
using Himall.Web.Framework;
using Himall.Application;
using Senparc.Weixin.MP.CommonAPIs;
using Himall.Web.Models;

namespace Himall.Web.Areas.SellerAdmin.Controllers
{
    /// <summary>
    /// 发收货地址
    /// </summary>
    public class ShopShipperController : BaseSellerController
    {
        private long CurShopId { get; set; }
        public ShopShipperController()
        {
            //退出登录后，直接进入controller异常处理
            if (CurrentSellerManager != null)
            {
                CurShopId = CurrentSellerManager.ShopId;
            }
        }

        public ActionResult Management()
        {
            return View();
        }

        [UnAuthorize]
        [HttpPost]
        public JsonResult List(int page, int rows)
        {
            var result = ShopShippersApplication.GetShopShippers(CurrentSellerManager.ShopId);
            DataGridModel<ShopShipper> model = new DataGridModel<ShopShipper>
            {
                rows = result,
                total = result.Count
            };
            return Json(model, true);
        }

        public ActionResult Add(long id = 0)
        {
            int sceneid = 0;
            string ticketstr = "";
            var settings = SiteSettingApplication.SiteSettings;
            try
            {
                if (!string.IsNullOrWhiteSpace(settings.WeixinAppId) && !string.IsNullOrWhiteSpace(settings.WeixinAppSecret))
                {
                    string token = AccessTokenContainer.TryGetToken(settings.WeixinAppId, settings.WeixinAppSecret);
                    if (string.IsNullOrWhiteSpace(token))
                    {
                        token = AccessTokenContainer.TryGetToken(settings.WeixinAppId, settings.WeixinAppSecret, true);
                    }

                    SceneModel scene = new SceneModel(QR_SCENE_Type.ShopShipper)
                    {
                        //Object = CurrentUser.Id.ToString()
                    };
                    SceneHelper helper = new SceneHelper();
                    sceneid = helper.SetModel(scene);
                    var ticket = Senparc.Weixin.MP.AdvancedAPIs.QrCode.QrCodeApi.Create(token, 300, sceneid);
                    ticketstr = ticket.ticket;
                }
            }
            catch {
                Log.Error("设置退货地址出错：微信配置错误，无法获取到微信凭证");
            }
            ViewBag.ticket = ticketstr;
            ViewBag.Sceneid = sceneid;
            ShopShipper data = new ShopShipper
            {
                ShopId = CurShopId
            };
            if (id > 0)
            {
                data = ShopShippersApplication.GetShopShipper(CurShopId, id);
                if (data == null)
                {
                    throw new HimallException("错误的参数");
                }
            }
            return View(data);
        }

        public JsonResult Save(ShopShipper model)
        {
            if (model.RegionId <= 0)
            {
                ModelState.AddModelError("Latitude", "请选择发货地区");
            }
            if (!model.Latitude.HasValue || !model.Longitude.HasValue)
            {
                ModelState.AddModelError("Latitude", "请定位发货地址");
            }
            if (ModelState.IsValid)
            {
                bool isadd = false;
                if (model.Id == 0)
                {
                    isadd = true;
                }
                model.ShopId = CurShopId;
                if (isadd)
                {
                    ShopShippersApplication.Add(CurShopId, model);
                }
                else
                {
                    var curdata = ShopShippersApplication.GetShopShipper(CurShopId, model.Id);
                    if (curdata == null)
                    {
                        throw new HimallException("错误参数");
                    }
                    UpdateModel(curdata);
                    ShopShippersApplication.Update(CurShopId, curdata);
                }
                return Json(new Result() { success = true, msg = "保存发收货地址成功" });
            }
            else
            {
                return Json(new Result() { success = false, msg = "数据参数错误" });
            }
        }

        public JsonResult Delete(long id)
        {
            ShopShippersApplication.Delete(CurShopId, id);
            return Json(new Result { success = true });
        }
        public JsonResult SetDefaultSend(long id)
        {
            ShopShippersApplication.SetDefaultSendGoodsShipper(CurShopId, id);
            return Json(new Result { success = true });
        }
        public JsonResult SetDefaultGet(long id)
        {
            ShopShippersApplication.SetDefaultGetGoodsShipper(CurShopId, id);
            return Json(new Result { success = true });
        }
        public JsonResult SetDefaultVerification(long id)
        {
            ShopShippersApplication.SetDefaultVerificationShipper(CurShopId, id);
            return Json(new Result { success = true });
        }
    }
}