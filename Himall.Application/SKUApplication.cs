using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himall.Core;
using Himall.IServices;
using Himall.DTO;

namespace Himall.Application
{
    public class SKUApplication : BaseApplicaion<ISkuService>
    {
        public List<SKU> GetDisplaySKUsByProduct(long product)
        {
            return GetDisplaySKUsByProducts(new List<long> { product });
        }
        public List<SKU> GetDisplaySKUsByProducts(List<long> products)
        {
            var skus = ProductManagerApplication.GetSKUByProducts(products);

            var types = TypeApplication.GetTypes();
            return new List<SKU>();
        }
    }
}
