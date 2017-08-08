using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class ApplicationTest
    {
        [TestMethod]
        public void LoginTest()
        {
            // Create application in case it doesn't exist
            var app = InsertApplication();
            DataLib.Repository repo = new DataLib.Repository();
            Assert.IsTrue(repo.CheckAuthentication(app.Application_Id, app.Secret));
        }

        [TestMethod]
        public void TokenAuthenticationTest()
        {
            // Create application in case it doesn't exist
            var app = InsertApplication();
            DataLib.Repository repo = new DataLib.Repository();
            var token = repo.GenerateToken(app.Application_Id);
            Assert.IsTrue(repo.CheckTokenAuthentication(token.Token));
        }

        [TestMethod]
        public void InsertApplicationTest()
        {
            var app = InsertApplication();
            Assert.IsNotNull(app);
        }

        public DataLib.Models.ApplicationModel InsertApplication()
        {
            DataLib.Repository repo = new DataLib.Repository();
            var model = new DataLib.Models.ApplicationModel()
            {
                Application_Id = Guid.NewGuid().ToString().Replace("-", ""),
                Display_Name = "UnitTest",
                Secret = "test"
            };
            repo.InsertApplication(model);
            var app = repo.GetApplication(model.Application_Id);
            return app;
        }
    }
}
