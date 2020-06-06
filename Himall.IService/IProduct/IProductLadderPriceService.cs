using System.Collections.Generic;
using Himall.Entities;

namespace Himall.IServices
{
    public interface IProductLadderPriceService : IService
	{
		/// <summary>
		/// 根据商品id获取sku信息
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
        List<ProductLadderPriceInfo> GetLadderPricesByProductIds(long productId);

        List<ProductLadderPriceInfo> GetLadderPricesByProductIds(List<long> products);

    }
}
