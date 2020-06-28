using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Test_Automation.tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

/*
//Create chrome driver instance for launching the browser application
//Create methods for UI actions
*/

namespace Test_Automation.utilities
{
    public class WebDriverInstance
    {
        private IWebDriver driver;
        public void createWebDriver()
        {
            //Create webdriver
            new WebDriverManager.DriverManager().SetUpDriver(new WebDriverManager.DriverConfigs.Impl.ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            //Create chrome instance
            driver = new ChromeDriver(options);
        }
        public IWebDriver getDriver()
        {
            return driver;
        }

        public string screenShot()
        {
            try
            {
                //Use current report directory for saving images
                string filename = BaseTest.directory + @"\" + DateTime.Now.ToString("HHmmss") + ".jpg";
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(filename);
                return filename;
            }
            catch (System.Exception)
            {
                Assert.Fail("Failed to take screenshot");
                return null;
            }
        }

        public IWebElement findElementByCss(String css)
        {
            try
            {
                return driver.FindElement(By.CssSelector(css));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                return null;
            }
        }

        public IWebElement findElementByXpath(String xpath)
        {
            try
            {
                return driver.FindElement(By.XPath(xpath));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                return null;
            }
        }
        public bool clickElementByXpath(String xpath)
        {
            try
            {
               driver.FindElement(By.XPath(xpath)).Click();
               return true;
            }
            catch (System.Exception)
            {
               return false;
            }
        }
        public bool SendKeys(string css, string text)
        {
            try
            {
                driver.FindElement(By.CssSelector(css)).SendKeys(text);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public bool selectDropdown(IWebElement select, String option)
        {
            try
            {
                var selection = new SelectElement(select);
                selection.SelectByText(option);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public bool waitForElement(string xpath)
        {
            //Wait until the element is present
            try{
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var element = wait.Until(driver=>driver.FindElement(By.XPath(xpath)));
            return true;
            }catch(System.Exception){
                return false;
            }
        }
    }
}
