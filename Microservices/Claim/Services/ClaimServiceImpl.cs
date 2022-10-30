using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Claim.Models;
using Microsoft.Extensions.Configuration;

namespace Claim.Services
{
    public class ClaimServiceImpl:IClaimService
    {

        HealthClaimDBContext db;


        private IConfiguration _config;

        public ClaimServiceImpl(IConfiguration config, HealthClaimDBContext _db)
        {

            _config = config;
            db = _db;
        }

        public string ClaimAdd(Claimtbl obj)
        {
            string msg = "";
            try
            {
 
                    db.Claimtbls.Add(obj);
                    db.SaveChanges();
                    msg = "Claim entry Successful.";
                
            }
            catch
            {
                msg = "Claim entry Unsuccessful";
            }

            return msg;
        }


    }
}
