using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Automation.tests;
using Test_Automation.utilities;

namespace Test_Automation
{
    [TestClass]
    public class TestSuite : BaseTest
    {
        [DataTestMethod]
        [DynamicData((nameof(GetData)), DynamicDataSourceType.Method)]
        public void TestMethod1(Hashtable table)
        {
            testReport.Pass((string)table[0]);

        }
        public static IEnumerable<object[]> GetData()
        {   
            ExcelDataProvider testdata=new ExcelDataProvider();
            //Iterate through retrieved spreadsheet rows
            foreach(Hashtable row in testdata.getExcelData()){
                yield return new object[] { row };
            }
        }
    }
}
