using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebStaff.Helpers
{
    public class XlsxParser
    {

        //AddCell(table.GetRow(0).GetCell(0), "Фамилия");
        //    AddCell(table.GetRow(0).GetCell(1), "Имя");
        //    AddCell(table.GetRow(0).GetCell(2), "Отчество");
        //    AddCell(table.GetRow(0).GetCell(3), "Должность");
        //    AddCell(table.GetRow(0).GetCell(4), "Звание");
        //    AddCell(table.GetRow(0).GetCell(5), "Подразделение");
        //    AddCell(table.GetRow(0).GetCell(6), "Уволен");


        public MemoryStream CreateTableXlsx(List<StaffViewModel> staffs, int countRecord = 0)
        {
            MemoryStream result = new MemoryStream();
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("MySheet");
            //Create cells
            IRow row = sheet.CreateRow(0);
            ICell cell1 = row.CreateCell(0);
            ICell cell2 = row.CreateCell(1);
            ICell cell3 = row.CreateCell(2);
            ICell sumCell = row.CreateCell(3);

            //Set the value of the cells
            cell1.SetCellValue(10);
            cell2.SetCellValue(15);
            cell3.SetCellValue(20);

            //Add formula
            sumCell.SetCellFormula("sum(A1:C1)");
            workbook.Write(result);

            return result;
        }
    }
}
