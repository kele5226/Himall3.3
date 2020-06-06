using Himall.Core;
using Himall.IServices;
using Himall.Entities;

namespace Himall.Application
{
    public class ShopOpenApiApplication
    {
        static IShopOpenApiService _iShopOpenApiService = ObjectContainer.Current.Resolve<IShopOpenApiService>();

        /// <summary>
        /// 获取店铺的OpenApi配置
        /// </summary>
        /// <param name="appkey"></param>
        /// <returns></returns>
        public static ShopOpenApiSettingInfo Get(string appkey)
        {
            return _iShopOpenApiService.Get(appkey);
        }
    }
}
