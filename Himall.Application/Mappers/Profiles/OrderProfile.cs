using AutoMapper;
using Himall.Entities;
using System.Collections.Generic;

namespace Himall.Application.Mappers.Profiles
{
    public class OrderProfile:Profile
	{
		protected override void Configure()
		{
			base.Configure();

			CreateMap<OrderInfo, DTO.Order>();
			CreateMap<DTO.Order, OrderInfo>();

			CreateMap<OrderInfo, DTO.FullOrder>();
			CreateMap<DTO.FullOrder, OrderInfo>();

			CreateMap<OrderPayInfo, DTO.OrderPay>();
			CreateMap<DTO.OrderPay, OrderPayInfo>();

			CreateMap<OrderRefundInfo, DTO.OrderRefund>();
			CreateMap<DTO.OrderRefund, OrderRefundInfo>();

			CreateMap<OrderItemInfo, DTO.OrderItem>();
			CreateMap<DTO.OrderItem, OrderItemInfo>();

			CreateMap<OrderCommentInfo, DTO.OrderComment>();
			CreateMap<DTO.OrderComment, OrderCommentInfo>();

			CreateMap<OrderRefundLogInfo, DTO.OrderRefundlog>();
			CreateMap<DTO.OrderRefundlog, OrderRefundLogInfo>();

            CreateMap<VerificationRecordInfo,DTO.VerificationRecordModel>();
            CreateMap<DTO.VerificationRecordModel, VerificationRecordInfo>();

            CreateMap<OrderVerificationCodeInfo, DTO.OrderVerificationCodeModel>();
            CreateMap<DTO.OrderVerificationCodeModel, OrderVerificationCodeInfo>();
        }
	}
}
