using System.Collections;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Automation.tests;
using Test_Automation.utilities;

namespace Test_Automation.Pages
{
    public class applyForThePost : BaseTest
    {

        //Element locators
        private string header()
        {
            return "//h3[text()='Description']";
        }
        private string applyOnline()
        {
            return "//a[contains(text(),'Apply Online')]";
        }
        private string name()
        {
            return "#applicant_name";
        }
        private string email()
        {
            return "#email";
        }
        private string phone()
        {
            return "#phone";
        }
        private string apply()
        {
            return "#wpjb_submit";
        }
        private string submit()
        {
            return "#wpjb_submit";
        }
        private string uploadError(string error)
        {
            return "//li[text()='" + error + "']";
        }
        private string error, firstName, userEmail, phoneNumber, errorMessage;
        public void setTestData(Hashtable table)
        {
            firstName = (string)table[0];
            userEmail = (string)table[1];
            errorMessage = (string)table[2];
            phoneNumber = GenerateRundom.number();
        }
        public void executeTest()
        {
            //Verify home page content
            if (!validatePage())
            {
                testReport.Log(Status.Fail, error);
                Assert.Fail(error);
            }
            if (!completeApplicationForm())
            {
                testReport.Log(Status.Fail, error);
                Assert.Fail(error);
            }
        }
        private bool validatePage()
        {
            if (!BaseTest.driver.waitForElement(header()))
            {
                error = "Validate job description page";
                return false;
            }
            testReport.Log(Status.Pass, "Validated job description page");
            return true;
        }
        private bool completeApplicationForm()
        {
            if (!BaseTest.driver.scrollToElement(applyOnline()))
            {
                error = "Scroll to apply online";
                return false;
            }
            if (!BaseTest.driver.clickElementByXpath(applyOnline()))
            {
                error = "Click apply online";
                return false;
            }
            testReport.Log(Status.Pass, "Click apply online");
            if (!BaseTest.driver.waitForElementByCss(name()))
            {
                error = "Wait for the name text field ";
                return false;
            }
            if (!BaseTest.driver.SendKeys(name(), firstName))
            {
                error = "Enter name";
                return false;
            }
            testReport.Log(Status.Pass, "Entered name:" + firstName);
            if (!BaseTest.driver.SendKeys(email(), userEmail))
            {
                error = "Enter email";
                return false;
            }
            testReport.Log(Status.Pass, "Entered email:" + userEmail);
            if (!BaseTest.driver.SendKeys(phone(), phoneNumber))
            {
                error = "Enter phone number";
                return false;
            }
            testReport.Log(Status.Pass, "Entered phone:" + phoneNumber);
            if (!BaseTest.driver.clickElementByCss(apply()))
            {
                error = "Click apply online";
                return false;
            }
            if (!BaseTest.driver.waitForElement(uploadError(errorMessage)))
            {
                error = "Validated uploaded error message";
                return false;
            }
            testReport.Log(Status.Pass, "Validated error:" + errorMessage);
            return true;
        }
    }
}