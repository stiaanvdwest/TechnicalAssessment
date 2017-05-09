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
    public class AddressTests
    {
        [TestMethod()]
        public void AddressTest()
        {
            Address address = new Address();
            Assert.IsTrue(address.Number == 0);
            Assert.IsTrue(address.Street == String.Empty);
            Assert.IsTrue(address.FullAddress == $"{address.Number} {address.Street}");
        }

        [TestMethod()]
        public void AddressTest1()
        {
            string testAdd = "3 Redonda Peak Cresent";
            Address address = new Address(testAdd);
            Assert.IsTrue(address.Number == 3);
            Assert.IsTrue(address.Street == "Redonda Peak Cresent");
            Assert.IsTrue(address.FullAddress == testAdd);
        }
    }
}