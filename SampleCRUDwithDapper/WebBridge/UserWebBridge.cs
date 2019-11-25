using SampleCRUDwithDapper.Models;
using SampleCRUDwithDapper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SampleCRUDwithDapper.WebBridge
{
    public class UserWebBridge
    {
        private SampleCRUDDB _db;
        public UserWebBridge()
        {
            _db = new SampleCRUDDB();
        }

        public IEnumerable<UserInfoViewModel> GetAllUsersInfo()
        {
            var allUserInfo = new List<UserInfoViewModel>();
            var userdetails = _db.Users.ToList();

            foreach (var eachUser in userdetails)
            {
                var userInfoModel = new UserInfoViewModel
                {
                    UserId = eachUser.ID,
                    FirstName = eachUser.FirstName,
                    LastName = eachUser.LastName,
                    EmailId = eachUser.EmailId
                };
                var address = _db.Addresses.Where(x => x.Id == eachUser.AddressId).FirstOrDefault();
                userInfoModel.UserAddress = new AddressViewModel
                {
                    Addess1 = address.Addess1,
                    Address2 = address.Address2,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    Id = address.Id
                };
                allUserInfo.Add(userInfoModel);
            }
            return allUserInfo;
        }

        public bool InsertUserInfo(UserInfoViewModel userInfoModel)
        {
            if (userInfoModel.EmailId == null || userInfoModel.Password == null || userInfoModel.FirstName == null || userInfoModel.LastName == null)
                return false;
            var userAddress = new Address
            {
                Addess1 = userInfoModel.UserAddress.Addess1,
                Address2 = userInfoModel.UserAddress.Address2,
                City = userInfoModel.UserAddress.City,
                State = userInfoModel.UserAddress.State,
                Country = userInfoModel.UserAddress.Country
            };
            var insertAddress = _db.Addresses.Add(userAddress);
            var insertCheck = _db.SaveChanges();
            if (insertCheck == 1)
            {
                var userInfo = new User
                {
                    FirstName = userInfoModel.FirstName,
                    LastName = userInfoModel.LastName,
                    EmailId = userInfoModel.EmailId,
                    AddressId = insertAddress.Id
                };

                var data = Encoding.ASCII.GetBytes(userInfoModel.Password);
                var sha1 = new SHA1CryptoServiceProvider();
                userInfo.Password = sha1.ComputeHash(data);
                _db.Users.Add(userInfo);
                _db.SaveChanges();
                _db.Dispose();
                return true;
            }
            return false;
        }
        public bool DeleteUser(int Id)
        {
            int deletedUser = _db.Database.ExecuteSqlCommand("DELETE FROM [User] where Id = " + Id);
            _db.SaveChanges();
            _db.Dispose();
            if (deletedUser == 1)
                return true;
            return false;
        }
    }
}