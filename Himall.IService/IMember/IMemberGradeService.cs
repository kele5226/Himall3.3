using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himall.Entities;

namespace Himall.IServices
{
    public interface IMemberGradeService : IService
    {
        /// </summary>
        /// 
        /// <param name="model"></param>
        void AddMemberGrade(MemberGradeInfo model);

        void UpdateMemberGrade(MemberGradeInfo model);


        void DeleteMemberGrade(long id);

        MemberGradeInfo GetMemberGrade(long id);

        List<MemberGradeInfo> GetMemberGradeList();

        
    }
}
