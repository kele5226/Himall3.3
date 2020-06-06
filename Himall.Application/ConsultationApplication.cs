using Himall.CommonModel;
using Himall.DTO.QueryModel;
using Himall.Entities;
using Himall.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himall.Application
{
    public class ConsultationApplication:BaseApplicaion<IConsultationService>
    {
        /// <summary>
        /// 获取咨询数
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static int GetConsultationCount(ConsultationQuery query)
        {
            return Service.GetConsultationCount(query);
        }
        /// <summary>
        /// 获取咨询数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static QueryPageModel<ProductConsultationInfo> GetConsultations(ConsultationQuery query)
        {
            return Service.GetConsultations(query);
        }
    }
}
