using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalAssessmentExtension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessmentExtension.Tests
{
    [TestClass()]
    public class ProcessTechnicalAssessmentTests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            ProcessTechnicalAssessment processTechnicalAssessment = new ProcessTechnicalAssessment();
            processTechnicalAssessment.Process();

            string OuputDir = "Output";
            string FileOutput1 = "Output1.txt";

            string FileOutput2 = "Output2.txt";
            FileInfo fileInfo = new FileInfo($@"{OuputDir}\{FileOutput1}");
            Assert.IsTrue(fileInfo.Exists);
            Assert.IsTrue(fileInfo.Length > 0);
            fileInfo = new FileInfo($@"{OuputDir}\{FileOutput2}");
            Assert.IsTrue(fileInfo.Exists);
            Assert.IsTrue(fileInfo.Length > 0);
            Assert.IsTrue(processTechnicalAssessment.Clients.Count() > 0);
        }

        [TestMethod()]
        public void ProcessOutputFile2Test()
        {
            string OuputDir = "Output";
            string FileOutput2 = "Output2.txt";

            ProcessTechnicalAssessment processTechnicalAssessment = new ProcessTechnicalAssessment();
            processTechnicalAssessment.DeserializeCsvFile();
            processTechnicalAssessment.ProcessOutputFile2();
            FileInfo fileInfo = new FileInfo($@"{OuputDir}\{FileOutput2}");
            Assert.IsTrue(fileInfo.Exists);
            Assert.IsTrue(fileInfo.Length > 0);
            Assert.IsTrue(processTechnicalAssessment.Clients.Count() > 0);
        }

        [TestMethod()]
        public void ProcessOutputFile1Test()
        {
            string OuputDir = "Output";
            string FileOutput1 = "Output1.txt";

            ProcessTechnicalAssessment processTechnicalAssessment = new ProcessTechnicalAssessment();
            processTechnicalAssessment.DeserializeCsvFile();
            processTechnicalAssessment.ProcessOutputFile1();
            FileInfo fileInfo = new FileInfo($@"{OuputDir}\{FileOutput1}");
            Assert.IsTrue(fileInfo.Exists);
            Assert.IsTrue(fileInfo.Length > 0);
            Assert.IsTrue(processTechnicalAssessment.Clients.Count() > 0);
        }

        [TestMethod()]
        public void DeserializeCsvFileTest()
        {
            ProcessTechnicalAssessment processTechnicalAssessment = new ProcessTechnicalAssessment();
            processTechnicalAssessment.DeserializeCsvFile();
            Assert.IsTrue(processTechnicalAssessment.Clients.Count() > 0);
        }

        [TestMethod()]
        public void ProcessTechnicalAssessmentTest()
        {
            ProcessTechnicalAssessment processTechnicalAssessment = new ProcessTechnicalAssessment();
            Assert.IsNotNull(processTechnicalAssessment.Clients);
            Assert.IsTrue(processTechnicalAssessment.Clients.Count() == 0);
        }
    }
}