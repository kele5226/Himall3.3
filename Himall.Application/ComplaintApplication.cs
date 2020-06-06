﻿using Himall.DTO.QueryModel;
using Himall.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himall.Application
{
    public class ComplaintApplication : BaseApplicaion<IComplaintService>
    {
        /// <summary>
        /// 获取投诉数量
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static int GetOrderComplaintCount(ComplaintQuery query)
        {
            return Service.GetOrderComplaintCount(query);
        }
    }
}
