using System;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MagicBox.Common
{
    /// <summary>
    /// 使用NPOI组件进行Excel的数据导入、导出
    /// </summary>
    public class NPOIExcelHelper
    {
        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <param name="filename">文件名</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public static int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten, string filename)
        {
            int rowCount = 0;
            ISheet sheet = null;
            IWorkbook workbook = null;

            var fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (filename.IndexOf(".xlsx", StringComparison.OrdinalIgnoreCase) > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (filename.IndexOf(".xls", StringComparison.InvariantCultureIgnoreCase) > 0) // 2003版本
                workbook = new HSSFWorkbook();
            sheet = workbook.CreateSheet(sheetName);

            if (isColumnWritten) //写入DataTable的列名
            {
                IRow row = sheet.CreateRow(0);
                for (var j = 0; j < data.Columns.Count; ++j)
                {
                    row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                }
                rowCount = 1;
            }
            else
            {
                rowCount = 0;
            }

            for (var i = 0; i < data.Rows.Count; ++i)
            {
                IRow row = sheet.CreateRow(rowCount);
                for (var j = 0; j < data.Columns.Count; ++j)
                {
                    row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                }
                ++rowCount;
            }
            workbook.Write(fs); //写入到excel
            return rowCount;
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <param name="filename">文件名</param>
        /// <returns>返回的DataTable</returns>
        public static DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn, string filename)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            IWorkbook workbook = null;
            int startRow = 0;
            var fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            if (filename.IndexOf(".xlsx", StringComparison.OrdinalIgnoreCase) > 0) // 2007版本
                workbook = new XSSFWorkbook(fs);
            else if (filename.IndexOf(".xls", StringComparison.OrdinalIgnoreCase) > 0) // 2003版本
                workbook = new HSSFWorkbook(fs);

            sheet = workbook.GetSheet(sheetName) ?? workbook.GetSheetAt(0);

            IRow firstRow = sheet.GetRow(0);
            int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
            if (isFirstRowColumn)
            {
                for (int i = firstRow.FirstCellNum; i < cellCount; i++)
                {
                    ICell cell = firstRow.GetCell(i);
                    string cellValue = cell.StringCellValue;
                    if (cellValue != null)
                    {
                        DataColumn column = new DataColumn(cellValue);
                        data.Columns.Add(column);
                    }
                }
                startRow = sheet.FirstRowNum + 1;
            }
            else
            {
                startRow = sheet.FirstRowNum;
            }

            //最后一列的标号
            var rowCount = sheet.LastRowNum;
            for (var i = startRow; i <= rowCount; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null || row.FirstCellNum < 0) continue; //没有数据的行默认是null　　　　　　　

                DataRow dataRow = data.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                        dataRow[j] = row.GetCell(j).ToString();
                }
                data.Rows.Add(dataRow);
            }

            return data;
        }
    }
}