using Member.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Member.Models;

namespace Member.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        IMemberService memberService;
        public StateController(IMemberService _memberService)
        {
            memberService = _memberService;
        }

        [HttpGet]
        [Route("Get-State-All")]
        public IEnumerable<Statetbl> Getallbooks()
        {

            return memberService.GetAllState();


        }
    }
}
