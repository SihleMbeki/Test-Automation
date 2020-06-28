using NPOI.SS.UserModel;
using Test_Automation.tests;
using System;
using System.IO;
using NPOI.XSSF.UserModel;
using System.Collections;
using System.Collections.Generic;

namespace Test_Automation.utilities
{
    public class ExcelDataProvider
    {
        private string directory;
        public ExcelDataProvider()
        {
            directory = Environment.CurrentDirectory + @"\..\..\..\testdata";
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
                IWorkbook workbook = new XSSFWorkbook(new FileStream(directory + @"\users.xlsx", FileMode.Open));
                ISheet sheet = workbook.GetSheetAt(0);
                Hashtable items;
                //Iterate through sheet rows
                foreach (IRow row in sheet)
                {
                    //new Hashtable to store row cells data
                    if(row.RowNum==0){
                        continue;
                    }
                    items = new Hashtable();
                    for (int cell = 0; cell < row.LastCellNum; cell++)
                    {
                        //retrieve column data
                        items.Add(cell, row.GetCell(cell).ToString());
                    }
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