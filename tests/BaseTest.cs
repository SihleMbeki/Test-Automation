using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Test_Automation.tests
{
    public class BaseTest
    {
        public static string directory;
        protected string testname;
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void setup()
        {
            testname = TestContext.TestName;
            directory=Environment.CurrentDirectory+@"\..\..\..\reports\";
            directory+=DateTime.Now.ToString("dd MM yyyy HH:mm:ss").Replace(":","_").Replace(" ","_");
            System.IO.Directory.CreateDirectory(directory);
        }
        
        [TestCleanup]
        public void tearDown()
        {
        }
    }
}