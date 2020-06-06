using Himall.CommonModel;
using Himall.DTO.QueryModel;
using Himall.Entities;

namespace Himall.IServices
{
    public interface IOperationLogService : IService
    {
        /// <summary>
        /// 根据查询条件分页获取操作日志信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        QueryPageModel<LogInfo> GetPlatformOperationLogs(OperationLogQuery query);

        /// <summary>
        /// 增加平台日志信息
        /// </summary>
        /// <param name="info"></param>
        void AddPlatformOperationLog(LogInfo info);

        /// <summary>
        /// 增加平台日志信息
        /// </summary>
        /// <param name="info"></param>
        void AddSellerOperationLog(LogInfo info);

        /// <summary>
        ///根据ID删除平台日志信息
        /// </summary>
        /// <param name="id"></param>
        void DeletePlatformOperationLog(long id);
        bool ExistUrl(string pageUrl,long shopId);
    }
}
