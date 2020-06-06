using Himall.IServices;

namespace Himall.API
{
    public class UserInviteController : BaseApiController
    {
        public UserInviteController()
        {
        }
        public object Get()
        {
            CheckUserLogin();
            var userId = CurrentUser.Id;
            //var model = _iMemberInviteService.GetMemberInviteInfo(userId);
            var _iMemberInviteService = ServiceProvider.Instance<IMemberInviteService>.Create;
            var _iMemberIntegralService = ServiceProvider.Instance<IMemberIntegralService>.Create;
            var rule = _iMemberInviteService.GetInviteRule();
            var Integral = _iMemberIntegralService.GetIntegralChangeRule();
            string IntergralMoney = "0";
            if (Integral != null && Integral.IntegralPerMoney > 0)
            {
                IntergralMoney = (rule.InviteIntegral / (double)Integral.IntegralPerMoney).ToString("f2");
            }
            return new
            {
                success = true,
                InviteIntegral = rule.InviteIntegral,
                IntergralMoney = IntergralMoney,
                RegIntegral = rule.RegIntegral,
                ShareRule = rule.ShareRule,
                ShareTitle = rule.ShareTitle,
                ShareIcon = rule.ShareIcon
            };
        }
    }
}