using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himall.Core;
using Himall.DTO;
using Himall.IServices;

namespace Himall.Application
{

    public class SystemAgreementApplication
    {
        private static ISystemAgreementService _iSystemAgreementService = ObjectContainer.Current.Resolve<ISystemAgreementService>();

        /// <summary>
        /// 获取协议信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Entities.AgreementInfo GetAgreement(Entities.AgreementInfo.AgreementTypes type)
        {
            return _iSystemAgreementService.GetAgreement(type);
        }
        /// <summary>
        /// 添加协议
        /// </summary>
        /// <param name="model"></param>
        public static void AddAgreement(Entities.AgreementInfo model)
        {
            _iSystemAgreementService.AddAgreement(model);
        }
        /// <summary>
        /// 修改协议
        /// </summary>
        /// <param name="model"></param>
        public static bool UpdateAgreement(Entities.AgreementInfo model)
        {
            return _iSystemAgreementService.UpdateAgreement(model);
        }
    }
}
