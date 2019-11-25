using SampleCRUDwithDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCRUDwithDapper.ViewModels
{
    public class UserInfoViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string UserFullName {
            get
            {
                return FirstName + " " + LastName;
            }            
        }
        public AddressViewModel UserAddress { get; set; }
    }
}