using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Member.Services
{
    public class MemberServiceImpl: IMemberService
    {
        HealthClaimDBContext db;


        private IConfiguration _config;

        public MemberServiceImpl(IConfiguration config, HealthClaimDBContext _db)
        {

            _config = config;
            db = _db;
        }

        public MemberDet AuthenticateUser(MemberDet login, bool IsRegister)
        {
            try
            {
                if (IsRegister)
                {
                    if(login.MemberType=="Member")
                    {
                        login.CreateDate = System.DateTime.Now;                       
                        Random rnd = new Random();
                        login.PhysianId = rnd.Next(1,8);
                    }
                    db.MemberDets.Add(login);
                    db.SaveChanges();
                    return login;
                }
                if (db.MemberDets.Any(x => x.UserName == login.UserName && x.Password == login.Password))
                {
                    return db.MemberDets.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public string GenerateToken(MemberDet login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var cradentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["jwt:Issuer"],
                _config["jwt:Audience"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: cradentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<MemberDet> GetAll()
        {

            return db.MemberDets;

        }


        public IEnumerable<MemberList> GetMemberClaim()
        {


            var memberlist = (from pd in db.MemberDets.Where(x => x.MemberType == "Member")
                              join ph in db.PhysicianDets on pd.PhysianId equals ph.PhysicianId
                              join od in db.Claimtbls on pd.MemberId equals od.MemberId
                              into gj
                              from fd in gj.DefaultIfEmpty()
                              select new
                            {
                                 MemberId = pd.MemberId,
                                 FirstName = pd.FirstName,
                                 LastName = pd.LastName,
                                 PhysianId = pd.PhysianId,
                                 PhysicianName = ph.PhysicianName,
                                 ClaimId = fd == null ? 0 : fd.ClaimId,
                                 ClaimAmount = fd == null ? 0 : fd.ClaimAmount,
                                 ClaimDate = fd == null ? Convert.ToDateTime("9999-09-09") : fd.ClaimDate,
                               

                            }).ToList();

            MemberList memberList;
            List<MemberList> memberLists = new List<MemberList>();
            foreach (var item in memberlist)
            {
                memberList = new MemberList();

                memberList.MemberId = item.MemberId;
                memberList.FirstName = item.FirstName;
                memberList.LastName = item.LastName;
                memberList.PhysianId = item.PhysianId;
                memberList.PhysicianName = item.PhysicianName;
                memberList.ClaimId = item.ClaimId;
                memberList.ClaimAmount = item.ClaimAmount;
                memberList.ClaimDate = Convert.ToDateTime(item.ClaimDate.ToString()).ToString("dd/MM/yyyy");
                memberList.ClaimDate = memberList.ClaimDate == "09-09-9999" ? "" : memberList.ClaimDate;
                memberList.btnVisible = true;


                memberLists.Add(memberList);

            }

            return memberLists;

        }

        public IEnumerable<MemberList> GetMemberClaim(int memberId)
        {


            var memberlist = (from pd in db.MemberDets.Where(x => x.MemberId== memberId)
                              join ph in db.PhysicianDets on pd.PhysianId equals ph.PhysicianId
                              join od in db.Claimtbls on pd.MemberId equals od.MemberId
                              into gj
                              from fd in gj.DefaultIfEmpty()
                              select new
                              {
                                  MemberId = pd.MemberId,
                                  FirstName = pd.FirstName,
                                  LastName = pd.LastName,
                                  PhysianId = pd.PhysianId,
                                  PhysicianName = ph.PhysicianName,
                                  ClaimId = fd == null ? 0 : fd.ClaimId,
                                  ClaimAmount = fd == null ? 0 : fd.ClaimAmount,
                                  ClaimDate = fd == null ? Convert.ToDateTime("9999-09-09") : fd.ClaimDate,


                              }).ToList();

            MemberList memberList;
            List<MemberList> memberLists = new List<MemberList>();
            foreach (var item in memberlist)
            {
                memberList = new MemberList();

                memberList.MemberId = item.MemberId;
                memberList.FirstName = item.FirstName;
                memberList.LastName = item.LastName;
                memberList.PhysianId = item.PhysianId;
                memberList.PhysicianName = item.PhysicianName;
                memberList.ClaimId = item.ClaimId;
                memberList.ClaimAmount = item.ClaimAmount;
                memberList.ClaimDate = Convert.ToDateTime(item.ClaimDate.ToString()).ToString("dd/MM/yyyy");
                memberList.ClaimDate = memberList.ClaimDate == "09-09-9999" ? "" : memberList.ClaimDate;
                memberList.btnVisible = false;


                memberLists.Add(memberList);

            }

            return memberLists;

        }

        public IEnumerable<MemberList> GetSearchMemberClaim(MemberList obj)
        {


            var memberlist = (from pd in db.MemberDets.Where(x => (x.FirstName==obj.FirstName || obj.FirstName=="") && (x.LastName==obj.LastName || obj.LastName=="") && (x.MemberId==obj.MemberId || obj.MemberId==0))
                              join ph in db.PhysicianDets.Where(x => (x.PhysicianName == obj.PhysicianName || obj.PhysicianName == "")) on pd.PhysianId equals ph.PhysicianId
                              join od in db.Claimtbls on pd.MemberId equals od.MemberId
                              into gj
                              from fd in gj.DefaultIfEmpty()
                              select new
                              {
                                  MemberId = pd.MemberId,
                                  FirstName = pd.FirstName,
                                  LastName = pd.LastName,
                                  PhysianId = pd.PhysianId,
                                  PhysicianName = ph.PhysicianName,
                                  ClaimId = fd == null ? 0 : fd.ClaimId,
                                  ClaimAmount = fd == null ? 0 : fd.ClaimAmount,
                                  ClaimDate = fd == null ? Convert.ToDateTime("9999-09-09") : fd.ClaimDate,


                              }).ToList();

            MemberList memberList;
            List<MemberList> memberLists = new List<MemberList>();
            foreach (var item in memberlist)
            {
                memberList = new MemberList();

                memberList.MemberId = item.MemberId;
                memberList.FirstName = item.FirstName;
                memberList.LastName = item.LastName;
                memberList.PhysianId = item.PhysianId;
                memberList.PhysicianName = item.PhysicianName;
                memberList.ClaimId = item.ClaimId;
                memberList.ClaimAmount = item.ClaimAmount;
                memberList.ClaimDate = Convert.ToDateTime(item.ClaimDate.ToString()).ToString("dd/MM/yyyy");
                memberList.ClaimDate = memberList.ClaimDate == "09-09-9999" ? "" : memberList.ClaimDate;
                memberList.btnVisible = true;


                memberLists.Add(memberList);

            }

            return memberLists;

        }


        public bool ExistingMember(MemberDet obj)
        {
            bool rtn = false;
            var existingMember = db.MemberDets.Where(x => x.UserName == obj.UserName)
                                                       .FirstOrDefault<MemberDet>();

            if(existingMember!=null)
            {
                rtn= true;
            }


            return rtn;

        }

        //--=== Member ===---
        public string MemberAdd(MemberDet obj)
        {
            string msg = "";
            try
            {
                var existingMember = db.MemberDets.Where(x => x.UserName == obj.UserName)
                                                            .FirstOrDefault<MemberDet>();

                if (existingMember != null)
                {
                    msg = "This member is already exists.";
                }
                else
                {
                    obj.CreateDate = System.DateTime.Now;
                    obj.MemberType = "Member";
                    Random rnd = new Random();
                    obj.PhysianId=rnd.Next(1,8);
                    db.MemberDets.Add(obj);
                    db.SaveChanges();
                    msg= "Record entry Successful.";
                }
            }
            catch
            {
                msg = "Record entry unsuccessful";
            }

            return msg;
        }

        public IEnumerable<PhysicianDet> GetAllPhysician()
        {

            return db.PhysicianDets;

        }

        //public IEnumerable<Order> GetMemberList()
        //{


        //    var booklist = (from pd in db.BookDets
        //                    join od in db.TblPayments.Where(x => x.PaymentBy == id) on pd.Id equals od.BookId
        //                    select new
        //                    {
        //                        BookId = pd.Id,
        //                        BookTitle = pd.BookTitle,
        //                        BookCategory = pd.BookCategory,
        //                        BookPrice = pd.BookPrice,
        //                        PaymentId = od.PaymentId,
        //                        InvoiceNo = od.InvoiceNo,
        //                        PaymentDate = od.PaymentDate,
        //                        Paymentname = od.PaymentName,
        //                        CancelOrder = od.CancelOrder,

        //                    }).ToList();

        //    Order bookord;
        //    List<Order> olist = new List<Order>();
        //    foreach (var item in booklist)
        //    {
        //        bookord = new Order();

        //        bookord.PaymentId = item.PaymentId;
        //        bookord.BookId = item.BookId;
        //        bookord.BookTitle = item.BookTitle;
        //        bookord.BookPrice = item.BookPrice;
        //        bookord.InvoiceNo = item.InvoiceNo;
        //        bookord.PaymentDate = Convert.ToDateTime(item.PaymentDate.ToString()).ToString("dd/MM/yyyy");
        //        bookord.PaymentName = item.Paymentname;
        //        bookord.CancelOrder = item.CancelOrder;


        //        olist.Add(bookord);

        //    }

        //    return olist;

        //}


        //--=== State Controller ===--

        public IEnumerable<Statetbl> GetAllState()
        {

            return db.Statetbls;

        }

    }
}
