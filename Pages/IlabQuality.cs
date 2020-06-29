using System.Collections;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Automation.tests;

namespace Test_Automation.Pages
{
    public class IlabQuality : BaseTest
    {

        //Element locators
        private string title()
        {
            return "//h2[text()='WHY CHOOSE iLAB?']";
        }

        private string careersNavigation()
        {
            return "#menu-primary-right-menu a[href='https://www.ilabquality.com/careers/']";
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
            if (!navigateToCareers())
            {
                testReport.Log(Status.Fail, error);
                Assert.Fail(error);
            }
        }
        private bool validatePage()
        {
            if (!BaseTest.driver.waitForElement(title()))
            {
                error = "Validate home page";
                return false;
            }
            testReport.Log(Status.Pass, "Validated home page");
            return true;
        }
        private bool navigateToCareers()
        {
            if (!BaseTest.driver.clickElementByCss(careersNavigation()))
            {
                error = "Click careers";
                return false;
            }
            testReport.Log(Status.Pass, "Click careers");
            return true;
        }
    }
}