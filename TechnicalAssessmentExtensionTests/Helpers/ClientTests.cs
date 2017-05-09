using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalAssessmentExtension.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessmentExtension.Helpers.Tests
{
    [TestClass()]
    public class ClientTests
    {
        [TestMethod()]
        public void ClientTest()
        {
            Client cl = new Client();
            Assert.IsTrue(cl.FirstName == string.Empty);
            Assert.IsTrue(cl.LastName == string.Empty);
            Assert.IsTrue(cl.AddressString == string.Empty);
            Assert.IsTrue(cl.PhoneNumber == string.Empty);
            Assert.IsNotNull(cl.Address);

        }
    }
}