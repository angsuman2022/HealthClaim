using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Member.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Member.Services;

namespace Member.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IMemberService memberService;
        public LoginController(IMemberService _memberService)
        {
            memberService = _memberService;
        }

        [HttpGet]
        public IEnumerable<MemberDet> get()
        {
            return memberService.GetAll();
        }

        [HttpPost]
        [Route("login-user")]

        public IActionResult Login(MemberDet login)
        {
            IActionResult response = Unauthorized();
            var loguser = memberService.AuthenticateUser(login, false);
            if (loguser != null)
            {
                var tokenString = memberService.GenerateToken(loguser);
                response = Ok(new { token = tokenString, userid = loguser.MemberId, role = loguser.MemberType });
            }
            return response;

        }


        [HttpPost]
        [Route("register-user")]
        public IActionResult Register(MemberDet login)
        {
            bool result = memberService.ExistingMember(login);
            if(result)
            {
                return Ok(new { status="This Member is already exists." });
            }
            IActionResult response = Unauthorized();
            var user = memberService.AuthenticateUser(login, true);
            if (user != null)
            {
                var tokenString = memberService.GenerateToken(user);
                response = Ok(new { token = tokenString, userid = user.MemberId, role = user.MemberType });
            }
            return response;

        }


    }
}
