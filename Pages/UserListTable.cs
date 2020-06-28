using System.Collections;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Automation.tests;

namespace Test_Automation.Pages
{
    public class UserListTable : BaseTest
    {

        //Element locators
        private string title()
        {
            return "//title[text()='Protractor practice website - WebTables']";
        }

        private string addUser()
        {
            return "td[ng-show='actions.add.url'] button[type='add']";
        }

        private string addUserDialog()
        {
            return "//h3[text()='Add User']";
        }

        private string firstname()
        {
            return "input[name='FirstName']";
        }

        private string lastname()
        {
            return "input[name='LastName']";
        }

        private string username()
        {
            return "input[name='UserName']";
        }

        private string password()
        {
            return "input[name='Password']";
        }

        private string email()
        {
            return "input[name='Email']";
        }

        private string cellphone()
        {
            return "input[name='Mobilephone']";
        }

        private string customer(string option)
        {
            return "//label[text()='" + option + "']/input";
        }

        private string role()
        {
            return "select[name='RoleId']";
        }

        private string save()
        {
            return "button[ng-click='save(user)']";
        }

        private string validateTableData(string value, string index)
        {
            return "//table[@table-title='Smart Table example']/tbody/tr[position()=1]/td[text()='" + value
                    + "' and position()=" + index + "]";
        }
        private string firstName, lastName, userName, userRole, userEmail, cell, userPassword, customerType, error;
        public void testData(Hashtable testData)
        {
            //Test case data
            this.firstName = (string)testData[0];
            this.lastName = (string)testData[1];
            this.userName = (string)testData[2];
            this.userRole = (string)testData[3];
            this.userEmail = (string)testData[4];
            this.cell = (string)testData[5];
            this.userPassword = (string)testData[6];
            this.customerType = (string)testData[7];

            //Verify that the username is unique
            if(!users.Contains(userName)){
            users.Add(userName);
            }else{
            testReport.Log(Status.Fail, "Username already used");
            Assert.Fail();

            }
        }
        public void executeTest()
        {
            if (!validatePage())
            {
                testReport.Log(Status.Fail, error);
                Assert.Fail(error);
            }

            if (!addNewUser())
            {
                testReport.Log(Status.Fail, error);
                Assert.Fail(error);
            }
            if (!validateUserRecord())
            {
                testReport.Log(Status.Fail, error);
                Assert.Fail(error);
            }
        }

        private bool validatePage()
        {
            if (!BaseTest.driver.waitForElement(title()))
            {
                error = "Failed to validate page title";
                return false;
            }
            testReport.Log(Status.Pass, "Validated user list table page");
            return true;
        }

        private bool addNewUser()
        {
            driver.findElementByCss(addUser()).Click();
            testReport.Log(Status.Pass, "Click add user");

            if (!driver.waitForElement(addUserDialog()))
            {
                testReport.Log(Status.Fail, "Validate add user dialog");
                return false;
            }

            driver.findElementByCss(firstname()).SendKeys(firstName);
            testReport.Log(Status.Pass, "Entered username:" + firstName);

            driver.findElementByCss(lastname()).SendKeys(lastName);
            testReport.Log(Status.Pass, "Entered lastname:" + lastName);

            driver.findElementByCss(username()).SendKeys(userName);
            testReport.Log(Status.Pass, "Entered username:" + userName);

            driver.findElementByCss(password()).SendKeys(userPassword);
            testReport.Log(Status.Pass, "Entered password:" + userPassword);

            if (!driver.clickElementByXpath(customer(customerType)))
            {
                error = "Failed to click customer type";
                return false;
            }

            testReport.Log(Status.Pass, "Selected customer:" + customerType);

            driver.findElementByCss(email()).SendKeys(userEmail);
            testReport.Log(Status.Pass, "Entered email:" + userEmail);

            driver.selectDropdown(driver.findElementByCss(role()), userRole);
            testReport.Log(Status.Pass, "Selected role:" + userRole);

            driver.findElementByCss(cellphone()).SendKeys(cell);
            testReport.Log(Status.Pass, "Entered cellphone:" + cell);

            driver.findElementByCss(save()).Click();
            testReport.Log(Status.Pass, "Clicked save");
            return true;

        }

        public bool validateUserRecord()
        {
            if (!driver.waitForElement(validateTableData(userName, "3")))
            {
                error = "Validate username :" + userName;
                return false;
            }

            if (!driver.waitForElement(validateTableData(firstName, "1")))
            {
                error = "Validate firstname:" + firstName;
                return false;
            }

            if (!driver.waitForElement(validateTableData(lastName, "2")))
            {
                error = "Validate lastname:" + lastName;
                return false;
            }

            if (!driver.waitForElement(validateTableData(userRole, "6")))
            {
                error = "Validate role:" + userRole;
                return false;
            }

            if (!driver.waitForElement(validateTableData(userEmail, "7")))
            {
                error = "Validate email:" + userEmail;
                return false;
            }

            if (!driver.waitForElement(validateTableData(cell, "8")))
            {
                error = "Validate cellphone:" + cell;
                return false;
            }

            if (!driver.waitForElement(validateTableData(customerType, "5")))
            {
                error = "Validate customer:" + customerType;
                return false;
            }
            return true;
        }
    }
}