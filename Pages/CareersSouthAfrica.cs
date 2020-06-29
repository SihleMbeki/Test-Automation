using System.Collections;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Automation.tests;

namespace Test_Automation.Pages
{
    public class CareersSouthAfrica : BaseTest
    {

        //Element locators
        private string title()
        {
            return "//title[text()='SOUTH AFRICA | iLAB']";
        }
        private string currentOpening()
        {
            return "(//a[@class='wpjb-job_title wpjb-title'])[1]";
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
            if (!navigateToCurrentOpening())
            {
                testReport.Log(Status.Fail, error);
                Assert.Fail(error);
            }
        }
       private bool validatePage()
        {
            if (!BaseTest.driver.waitForElement(title()))
            {
                error = "Validate South Africa page";
                return false;
            }
            testReport.Log(Status.Pass, "Validated South Africa page");
            return true;
        }
        private bool navigateToCurrentOpening()
        {
            if (!BaseTest.driver.clickElementByXpath(currentOpening()))
            {
                error = "Click on first available job";
                return false;
            }
            testReport.Log(Status.Pass, "Click on first available job");
            return true;
        }
    }
}