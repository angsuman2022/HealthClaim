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
                    //var existingMember = db.MemberDets.Where(x => x.UserName == login.UserName)
                    //                                            .FirstOrDefault<MemberDet>();
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
