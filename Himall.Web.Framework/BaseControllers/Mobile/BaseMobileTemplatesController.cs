using Himall.Core.Helper;
using System.Web.Mvc;
using Himall.Application;
using Himall.CommonModel;
using System.Text.RegularExpressions;
using System;

namespace Himall.Web.Framework
{
    /// <summary>
    /// 移动端控制器基类(带模板)
    /// </summary>
    public abstract class BaseMobileTemplatesController : BaseMobileController
    {
        /// <summary>
        /// 当前销售员
        /// </summary>
        protected long? CurrentSpreadId { get; set; }
        /// <summary>
        /// 是否需要处理分销微信分享
        /// </summary>
        protected bool NeedDistributionWeiXinShare { get; set; }
        /// <summary>
        /// 前置处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string _tmp = string.Empty;

            _tmp = WebHelper.GetCookie(CookieKeysCollection.HIMALL_NEED_CLEAR_DISTRIBUTION_SPREAD_ID_COOKIE_NAME);
            int needclear = 0;
            if (!int.TryParse(_tmp, out needclear))
            {
                needclear = 0;
            }
            if (needclear == 1)
            {
                //WebHelper.SetCookie(CookieKeysCollection.HIMALL_DISTRIBUTION_SPREAD_ID_COOKIE_NAME, "0");
                WebHelper.SetCookie(CookieKeysCollection.HIMALL_NEED_CLEAR_DISTRIBUTION_SPREAD_ID_COOKIE_NAME, "0");
            }

            //处理销售员引流
            _tmp = Request[DISTRIBUTION_SPREAD_ID_PARAMETER_NAME];
            long SpreadId = 0;
            if (!long.TryParse(_tmp, out SpreadId))
            {
                SpreadId = 0;
            }

            if (SpreadId > 0)
            {
                //写入销售员信息
                WebHelper.SetCookie(CookieKeysCollection.HIMALL_DISTRIBUTION_SPREAD_ID_COOKIE_NAME, SpreadId.ToString());
            }
            if (SpreadId == 0)
            {
                //获取cookie里的销售员id
                _tmp = WebHelper.GetCookie(CookieKeysCollection.HIMALL_DISTRIBUTION_SPREAD_ID_COOKIE_NAME);
                if (!long.TryParse(_tmp, out SpreadId))
                {
                    SpreadId = 0;
                }
            }
            CurrentSpreadId = SpreadId;

            //处理销售员自身推广
            if (WebHelper.IsGet() && !WebHelper.IsAjax() && CurrentUser != null && SiteSettingApplication.SiteSettings.DistributionIsEnable)
            {
                //if (PlatformType == Core.PlatformType.WeiXin)
                {
                    var disobj = DistributionApplication.GetDistributor(CurrentUser.Id);
                    if (disobj != null && disobj.IsNormalDistributor)
                    {
                        NeedDistributionWeiXinShare = true;

                        if (string.IsNullOrWhiteSpace(Request[DISTRIBUTION_SPREAD_ID_PARAMETER_NAME]) || CurrentSpreadId != CurrentUser.Id)
                        {
                            CurrentSpreadId = CurrentUser.Id;
                            string url = Request.Url.ToString();
                            string jumpurl = "";
                            string regstr = @"([\?&])" + DISTRIBUTION_SPREAD_ID_PARAMETER_NAME + "=[^&]*(&?)";
                            jumpurl = Regex.Replace(url, regstr, "$1",RegexOptions.IgnoreCase);
                            if ("?&".IndexOf(jumpurl.Substring(jumpurl.Length - 1)) > -1) { jumpurl = jumpurl.Substring(0, jumpurl.Length - 1); }
                            if (jumpurl.IndexOf("?") > -1)
                            {
                                jumpurl += "&";
                            }
                            else
                            {
                                jumpurl += "?";
                            }
                            jumpurl += DISTRIBUTION_SPREAD_ID_PARAMETER_NAME + "=" + CurrentSpreadId;

                            Response.Clear();
                            Response.BufferOutput = true;
                            Response.Redirect(jumpurl);
                        }
                    }
                }
            }
            //关闭分销后处理地址
            if (!SiteSettingApplication.SiteSettings.DistributionIsEnable && !string.IsNullOrWhiteSpace(Request[DISTRIBUTION_SPREAD_ID_PARAMETER_NAME]))
            {
                string url = Request.Url.ToString();
                url = Regex.Replace(url, @"([\?&])" + DISTRIBUTION_SPREAD_ID_PARAMETER_NAME + "=[^&]*(&?)", "$1", RegexOptions.IgnoreCase);
                url = Regex.Replace(url, @"&$", "", RegexOptions.IgnoreCase);
                Response.Clear();
                Response.BufferOutput = true;
                Response.Redirect(url);
            }
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {

            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                var currentUserTemplate = "Default";
                if (PlatformType == Core.PlatformType.IOS || PlatformType == Core.PlatformType.Android)
                    currentUserTemplate = "APP";
                var template = string.IsNullOrEmpty(currentUserTemplate) ? "" : currentUserTemplate;
                var controller = filterContext.RequestContext.RouteData.Values["Controller"].ToString();
                var action = filterContext.RequestContext.RouteData.Values["Action"].ToString();
                if (string.IsNullOrWhiteSpace(viewResult.ViewName))
                {
                    viewResult.ViewName = string.Format(
                        "~/Areas/Mobile/Templates/{0}/Views/{1}/{2}.cshtml",
                        template,
                        controller,
                        action);
                    return;
                }
                else if (!viewResult.ViewName.EndsWith(".cshtml"))
                {
                    viewResult.ViewName = string.Format(
                         "~/Areas/Mobile/Templates/{0}/Views/{1}/{2}.cshtml",
                         template,
                         controller,
                         viewResult.ViewName);
                    return;
                }
            }
            base.OnResultExecuting(filterContext);
        }
    }
}
