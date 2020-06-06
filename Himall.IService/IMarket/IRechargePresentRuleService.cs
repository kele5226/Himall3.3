using Himall.CommonModel;
using Himall.DTO.QueryModel;
using Himall.Entities;
using System.Collections.Generic;

namespace Himall.IServices
{
    /// <summary>
    /// 充值赠送服务
    /// </summary>
    public interface IRechargePresentRuleService : IService
    {
        /// <summary>
        /// 新增修改充值赠送规则
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rules"></param>
        /// <param name="products"></param>
        void SetRules(IEnumerable<RechargePresentRuleInfo> rules);
        /// <summary>
        /// 获取充值赠送规则
        /// </summary>
        /// <returns></returns>
        List<RechargePresentRuleInfo> GetRules();
    }
}
