using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Automation.Pages;
using Test_Automation.tests;
using Test_Automation.utilities;

namespace Test_Automation
{
   
    [TestClass]
    public class TestSuite : BaseTest
    {
      
        /*
        //Call to data provider method
        //The called method returns enumerable object providing data for each run
        */
        [DataTestMethod]
        [DynamicData((nameof(getExcelData)), DynamicDataSourceType.Method)]
        public void excelDataTest(Hashtable table)
        {
            //Test page instance
            UserListTable userTableList = new UserListTable();
            userTableList.testData(table);
            //Execute test steps
            userTableList.executeTest();
        }
        [DataTestMethod]
        [DynamicData((nameof(getAccessData)), DynamicDataSourceType.Method)]
        public void accessDataTest(Hashtable table)
        {
            UserListTable userTableList = new UserListTable();
            userTableList.testData(table);
            userTableList.executeTest();
        }
        private static IEnumerable<object[]> getAccessData()
        {
            AccessDataProvider testdata = new AccessDataProvider();
            //Iterate through retrieved table rows
            foreach (Hashtable row in testdata.getAccesslData())
            {
                yield return new object[] { row };
            }
        }
        private static IEnumerable<object[]> getExcelData()
        {
            ExcelDataProvider testdata = new ExcelDataProvider();
            //Iterate through retrieved spreadsheet rows
            foreach (Hashtable row in testdata.getExcelData())
            {
                yield return new object[] { row };
            }
        }
    }
}
