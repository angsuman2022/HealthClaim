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


        string MemberAdd(MemberDet obj);


        IEnumerable<Statetbl> GetAllState();
    }
}
