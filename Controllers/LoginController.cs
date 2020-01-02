
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication20.Models;
using WebApplication20.VM;
using WebApplication20.VM;
using WebApplication20.Models;

namespace WebApplication20.Controllers
{
    [RoutePrefix("Api/login")]
    public class LoginController : ApiController
    {
        rentbikeEntities DB = new rentbikeEntities();
        [Route("InsertUser")]
        [HttpPost]
        // As argument is an object that contains user info
        public object InsertUser(Register Reg)
        {
            
                UserTbl user = new Models.UserTbl();
                     user.cardNum = Reg.cardNumber;
                    user.email = Reg.email;
                    user.password = Reg.password;
                    user.latitude = Reg.latitude;
                    user.longitude = Reg.longitude;              
                    DB.UserTbls.Add(user);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Record SuccessFully Saved." };
    
        
        }
       
        [HttpPost]
    
        public Response userLogin(Login login)
        { 
            // The user is successfully logged in if email and password match
            var log = DB.UserTbls.Where(x => x.email.Equals(login.Email) && x.password.Equals(login.Password)).FirstOrDefault();
            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new Response { Status = "Success", Message = "Login Successfully" };
        }
    }
}