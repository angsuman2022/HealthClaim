using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Member.Models;
using Member.Services;

namespace Member.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        IMemberService memberService;
        public MemberController(IMemberService _memberService)
        {
            memberService = _memberService;
        }

        [HttpGet]
        [Route("Get-Member-Claim")]
        public IEnumerable<MemberList> GetMemberClaim()
        {

            return memberService.GetMemberClaim();


        }

        [HttpGet]
        [Route("Get-Mem-Claim")]
        public IEnumerable<MemberList> GetMemClaim(int mId)
        {

            return memberService.GetMemberClaim(mId);


        }

        [HttpPost]
        [Route("Search-Claim")]
        public IEnumerable<MemberList> GetSearchMemberClaim( MemberList obj)
        {

            return memberService.GetSearchMemberClaim(obj);


        }

        [HttpGet]
        [Route("Get-Physician-All")]
        public IEnumerable<PhysicianDet> GetallPhysician()
        {

            return memberService.GetAllPhysician();


        }

        [HttpPost]
        [Route("Member-Add")]
        public IActionResult Post(MemberDet obj)
        {
            string chk = memberService.MemberAdd(obj);
          
                var response = new { Status = chk };
                return Ok(response);
            
        }
    }
}
