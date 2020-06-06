using Himall.Core;
using Himall.IServices;
using Himall.Entities;

namespace Himall.Application
{
    public class SettledApplication
    {
        private static ISettledService _iSettledService = ObjectContainer.Current.Resolve<ISettledService>();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mSettledInfo"></param>
        public static void AddSettled(SettledInfo mSettledInfo)
        {
            _iSettledService.AddSettled(mSettledInfo);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mSettledInfo"></param>
        public static void UpdateSettled(SettledInfo mSettledInfo)
        {
            _iSettledService.UpdateSettled(mSettledInfo);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
      public static  SettledInfo GetSettled()
        {
            return _iSettledService.GetSettled();
        }
    }
}
