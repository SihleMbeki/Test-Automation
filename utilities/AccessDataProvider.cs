using NPOI.SS.UserModel;
using System;
using System.IO;
using System.Data.OleDb;
using System.Collections;
using System.Data;

namespace Test_Automation.utilities
{
    public class AccessDataProvider
    {
        private string directory;
        public AccessDataProvider()
        {
            directory = Environment.CurrentDirectory + @"\..\..\..\testdata\users.accdb";
        }
        public ArrayList getAccesslData()
        {
            /*
            //Establish database connection and retrieve table
            //Iterate through table rows and read each column value as a string
            */
            ArrayList rowItems = new ArrayList();
            try
            {
                //database connection string
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + directory;
                string sqtStatment = "SELECT * FROM users";
                //create Objects of ADOConnection and ADOCommand  
                OleDbConnection myConn = new OleDbConnection(connectionString);
                myConn.Open();
                OleDbCommand command = new OleDbCommand(sqtStatment, myConn);
                OleDbDataReader reader = null;
                reader = command.ExecuteReader();
                Hashtable items;
                //Iterate through table rows
                while (reader.Read())
                {
                    items=new Hashtable();
                    //retrieve column data
                    items.Add(0, reader[1].ToString());
                    items.Add(1, reader[2].ToString());
                    items.Add(2, reader[3].ToString());
                    items.Add(3, reader[4].ToString());
                    items.Add(4, reader[5].ToString());
                    items.Add(5, reader[6].ToString());
                    items.Add(6, reader[7].ToString());
                    items.Add(7, reader[8].ToString());
                    rowItems.Add(items);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return rowItems;
        }
    }
}