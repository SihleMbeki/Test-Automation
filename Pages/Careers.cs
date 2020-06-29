using System.Collections;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Automation.tests;

namespace Test_Automation.Pages
{
    public class Careers : BaseTest
    {

        //Element locators
        private string header()
        {
            return "//h3[text()='INNOVATION IN QUALITY & TESTING']";
        }
        private string careersSouthAfrica()
        {
            return "a[href='/careers/south-africa/']";
        }
        string error;
        public void executeTest()
        {
            //Verify home page content
            if (!validatePage())
            {
                testReport.Log(Status.Fail, error);
                Assert.Fail(error);
            }
            if (!navigateToSoutAfrica())
            {
                testReport.Log(Status.Fail, error);
                Assert.Fail(error);
            }
        }
       private bool validatePage()
        {
            if (!BaseTest.driver.waitForElement(header()))
            {
                error = "Validate careers page";
                return false;
            }
            testReport.Log(Status.Pass, "Validated careers page");
            return true;
        }
        private bool navigateToSoutAfrica()
        {
            if (!BaseTest.driver.clickElementByCss(careersSouthAfrica()))
            {
                error = "Click South Africa";
                return false;
            }
            testReport.Log(Status.Pass, "Click South Africa");
            return true;
        }
    }
}