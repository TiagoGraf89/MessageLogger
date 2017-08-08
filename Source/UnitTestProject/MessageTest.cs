using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using DataLib.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void LogMessageTest()
        {
            var appTest = new ApplicationTest();
            var app = appTest.InsertApplication();
            DataLib.Repository repo = new DataLib.Repository();
            var log = new MessageModel()
            {
                Application_Id = app.Application_Id,
                Logger = "UnitTest",
                Message = "Unit Tested.",
                Level = "Test"
            };
            repo.InsertMessageLog(log);
        }

    }
}
