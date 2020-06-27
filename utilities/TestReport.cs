using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Test_Automation.tests;

namespace Test_Automation.utilities
{
    public class TestReport
    {
        private static AventStack.ExtentReports.ExtentReports reports { get; set; }
        public static void createReport()
        {
            //Generate reports instance for all the tests
            reports = new AventStack.ExtentReports.ExtentReports();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(BaseTest.directory+@"\");
            htmlReporter.Config.DocumentTitle = "Web Automation";
            htmlReporter.Config.Encoding = "utf-8";
            reports.AttachReporter(htmlReporter);
            reports.AddSystemInfo("Author", "Masakhane Matanzima");
        }
        public static ExtentTest createTest(string testname)
        {
            //If the report does not exist the new report is created 
            if (reports == null)
            {
                createReport();
            }
            //Create and return new test instance
            return reports.CreateTest(testname);
        }

        public static void closeReport()
        {
            //Before closing the test ,the verification is required in case it already closed by exceptions
            if (reports != null)
            {
                reports.Flush();
            }
        }
    }
}