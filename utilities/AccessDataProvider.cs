using NPOI.SS.UserModel;
using System;
using System.IO;
using System.Data.OleDb; 
using System.Collections;

namespace Test_Automation.utilities
{
    public class AccessDataProvider
    {
        private string directory;
        public AccessDataProvider()
        {
            directory = Environment.CurrentDirectory + @"\..\..\..\testdata\users.accdb";
        }
        public ArrayList getExcelData()
        {
            /*
            //Open test file and retrieve spreadsheet
            //Extract spread sheet content at index 0
            //loop through rows and read each cell value as a string
            */
            ArrayList rowItems = new ArrayList();
            try
            {
   string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = "+directory;  
     // string strSQL = "SELECT * FROM users"; 

       // create Objects of ADOConnection and ADOCommand  
        //using (OleDbConnection connection = new OleDbConnection(strDSN))
    {
    }
    // var con=new SqlCommand("","");
    //   var myConn = new SqlConnection(strDSN);  
    //   var myCmd = new OleDbDataAdapter(strSQL, myConn);  
    //   myConn.Open();  
            //     Hashtable items;
            //     //Iterate through sheet rows
            //     foreach (IRow row in sheet)
            //     {
            //         //new hash table to store row cells data
            //         items = new Hashtable();
            //         for (int cell = 0; cell < row.LastCellNum; cell++)
            //         {
            //             //retrieve column data
            //             items.Add(cell, row.GetCell(cell).ToString());
            //         }
            //         rowItems.Add(items);
            //     }
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            // }
            return rowItems;
        }
    }
}