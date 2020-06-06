using Himall.Core;
using Himall.IServices;

namespace Himall.Application
{
    public class AppBaseApplication
    {
        static IAppBaseService _iAppBaseService = ObjectContainer.Current.Resolve<IAppBaseService>();

        /// <summary>
        /// 通过appkey获取AppSecret
        /// </summary>
        /// <param name="appkey"></param>
        /// <returns></returns>
        public static string GetAppSecret(string appkey)
        {
            return _iAppBaseService.GetAppSecret(appkey);
        }
    }
}
