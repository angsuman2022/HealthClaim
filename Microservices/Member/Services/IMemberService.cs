using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Member.Models;

namespace Member.Services
{
    public interface IMemberService
    {

        MemberDet AuthenticateUser(MemberDet login, bool IsRegister);
        string GenerateToken(MemberDet login);
        IEnumerable<MemberDet> GetAll();
        bool ExistingMember(MemberDet obj);


        string MemberAdd(MemberDet obj);
        IEnumerable<MemberList> GetMemberClaim();
        IEnumerable<MemberList> GetMemberClaim(int memberId);
        IEnumerable<PhysicianDet> GetAllPhysician();
        IEnumerable<MemberList> GetSearchMemberClaim(MemberList obj);

        IEnumerable<Statetbl> GetAllState();
    }
}
