﻿using Himall.Application;
using Himall.Web.Framework;
using System.Linq;
using System.Web.Mvc;

namespace Himall.Web.Areas.Mobile.Controllers
{
    public class CustomerServicesController : BaseMobileTemplatesController
    {
        // GET: Mobile/CustomerServices
        public ActionResult PlatCustomerServices()
        {
            var services = CustomerServiceApplication.GetPlatformCustomerService(true, true);
            //var meiqia = CustomerServiceApplication.GetPlatformCustomerService(true, false).FirstOrDefault(p => p.Tool == Entities.CustomerServiceInfo.ServiceTool.MeiQia);
            //if (meiqia != null)
            //    services.Insert(0, meiqia);
            return View(services);
        }

        public ActionResult ShopCustomerServices(long shopId)
        {
            var customerServices = CustomerServiceApplication.GetMobileCustomerServiceAndMQ(shopId);
            //ViewBag.CustomerServices = customerServices;
            return View("PlatCustomerServices",customerServices);
        }
    }
}