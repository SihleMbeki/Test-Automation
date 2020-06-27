using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test_Automation.utilities;

/*
 TargetFramework:netcoreapp3.0
*/

namespace Test_Automation.tests
{
    public class BaseTest
    {
        //Set universal directory for the current test run
        public static string directory;
        protected ExtentTest testReport { get; set; }
        //Set test variable for the test and action child classes
        protected string testname;
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void setup()
        {
            //Extract test name to be used in the report
            testname = TestContext.TestName;
            directory = Environment.CurrentDirectory + @"\..\..\..\reports\";
            directory += DateTime.Now.ToString("dd MM yyyy HH:mm:ss").Replace(":", "_").Replace(" ", "_");
            System.IO.Directory.CreateDirectory(directory);

            //retrieve new test instance
            testReport = TestReport.createTest(testname);
        }

        [TestCleanup]
        public void tearDown()
        {
            /*
            When the test is complete or aborted the report status is logged.
            Pass and Failure status are logged and any unexpected will be logged as an error
            */
            var testResult = TestContext.CurrentTestOutcome;
            switch (testResult)
            {
                case UnitTestOutcome.Failed:
                    testReport.Log(Status.Fail, testname + " Failed");
                    break;
                case UnitTestOutcome.Passed:
                    testReport.Log(Status.Pass, testname + " Passed");
                    break;
                default:
                    testReport.Log(Status.Error, "Error occured");
                    break;
            }
            TestReport.closeReport();
        }
    }
}