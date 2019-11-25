using SampleCRUDwithDapper.Models;
using SampleCRUDwithDapper.ViewModels;
using SampleCRUDwithDapper.WebBridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleCRUDwithDapper.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private UserWebBridge _userWeb;
        public UserController()
        {
            _userWeb = new UserWebBridge();
        }

        [Route("")]
        [HttpPost]
        public bool InsertUser(UserInfoViewModel userDetails)
        {
            try
            {

                return _userWeb.InsertUserInfo(userDetails);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        [Route("UserInfo")]
        [HttpGet]
        public IEnumerable<UserInfoViewModel> GetUserInfo()
        {
            try
            {
                return _userWeb.GetAllUsersInfo();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        //[Route("UserInfo/{Id}")]
        //[HttpGet]
        //public User GetUserInfo(int Id)
        //{
        //    return _db.Users.Where(x => x.ID == Id).FirstOrDefault();
        //}
        [Route("DeletedUser/{Id}")]
        [HttpDelete]
        public bool DeleteUser(int Id)
        {
            return _userWeb.DeleteUser(Id);
        }
    }
}
