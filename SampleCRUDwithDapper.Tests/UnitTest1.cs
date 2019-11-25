using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleCRUDwithDapper.ViewModels;
using SampleCRUDwithDapper.WebBridge;

namespace SampleCRUDwithDapper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var userWebBridge = new UserWebBridge();
            var userInfoViewModel = new UserInfoViewModel();
            var result = userWebBridge.InsertUserInfo(userInfoViewModel);
            
        }
    }
}
