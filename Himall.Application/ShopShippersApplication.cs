using Himall.CommonModel;
using Himall.Core;
using Himall.DTO;
using Himall.IServices;
using Himall.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himall.Application
{
    public class ShopShippersApplication
    {
        static IShopShippersServiceService _iShopShippersServiceService = ObjectContainer.Current.Resolve<IShopShippersServiceService>();

        /// <summary>
        /// 获得默认发货地址信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static ShopShipper GetDefaultSendGoodsShipper(long shopId)
        {
            var data = _iShopShippersServiceService.GetDefaultSendGoodsShipper(shopId);
            var result = AutoMapper.Mapper.Map<ShopShipper>(data);
            return result;
        }
        /// <summary>
        /// 获得默认收货地址信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static ShopShipper GetDefaultGetGoodsShipper(long shopId)
        {
            var data = _iShopShippersServiceService.GetDefaultGetGoodsShipper(shopId);
            var result = AutoMapper.Mapper.Map<ShopShipper>(data);
            return result;

        }
       /// <summary>
       /// 获得默认核销地址信息
       /// </summary>
       /// <param name="shopId"></param>
        public static ShopShipper GetDefaultVerificationShipper(long shopId)
        {
            var data = _iShopShippersServiceService.GetDefaultVerificationShipper(shopId);
            var result = AutoMapper.Mapper.Map<ShopShipper>(data);
            return result;
        }
        /// <summary>
        /// 设置默认发货地址信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="id"></param>
        public static void SetDefaultSendGoodsShipper(long shopId, long id)
        {
            _iShopShippersServiceService.SetDefaultSendGoodsShipper(shopId, id);
        }
        /// <summary>
        /// 设置默认收货地址信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="id"></param>
        public static void SetDefaultGetGoodsShipper(long shopId, long id)
        {
            _iShopShippersServiceService.SetDefaultGetGoodsShipper(shopId, id);
        }
        /// <summary>
        /// 设置默认核销地址信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="id"></param>
        public static void SetDefaultVerificationShipper(long shopId, long id)
        {
            _iShopShippersServiceService.SetDefaultVerificationShipper(shopId, id);
        }
        /// <summary>
        /// 获取发收货地址
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static ShopShipper GetShopShipper(long shopId, long id)
        {
            var data = _iShopShippersServiceService.GetShopShipper(shopId, id);
            var result = AutoMapper.Mapper.Map<ShopShipper>(data);
            return result;
        }
        /// <summary>
        /// 获取所有发收货地址
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static List<ShopShipper> GetShopShippers(long shopId)
        {
            var data = _iShopShippersServiceService.GetShopShippers(shopId);
            var result = AutoMapper.Mapper.Map<List<ShopShipper>>(data);
            return result;
        }
        /// <summary>
        /// 添加发收货地址
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="data"></param>
        public static void Add(long shopId, ShopShipper data)
        {
            var _d = AutoMapper.Mapper.Map<ShopShipperInfo>(data);
            _iShopShippersServiceService.Add(shopId, _d);
        }
        /// <summary>
        /// 修改发收货地址
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="data"></param>
        public static void Update(long shopId, ShopShipper data)
        {
            var _d = AutoMapper.Mapper.Map<ShopShipperInfo>(data);
            _iShopShippersServiceService.Update(shopId, _d);
        }
        /// <summary>
        /// 删除发收货地址
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="id"></param>
        public static void Delete(long shopId, long id)
        {
            _iShopShippersServiceService.Delete(shopId, id);
        }
    }
}
