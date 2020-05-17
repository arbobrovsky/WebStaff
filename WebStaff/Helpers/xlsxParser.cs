using NPOI.HSSF.Util;
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


        private void CreateAndSetValueCell(ISheet sheet, int indexRow, int indexCell, string text)
        {
            IRow rowTop = sheet.CreateRow(indexRow);
            ICell createCell = rowTop.CreateCell(indexCell);
            createCell.SetCellValue(text);
        }


        public MemoryStream CreateTableXlsx(List<StaffViewModel> staffs, int countRecord = 0)
        {
            MemoryStream result = new MemoryStream();
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("MySheet");


            //ICellStyle rowstyle = workbook.CreateCellStyle();
            //rowstyle.FillForegroundColor = IndexedColors.Red.Index;
            //rowstyle.FillPattern = FillPattern.SolidForeground;

            IFont font1 = workbook.CreateFont();
            // font1.Color = IndexedColors.Red.Index;
            font1.IsItalic = true;
            //  font1.Underline = FontUnderlineType.Double;
            font1.FontHeightInPoints = 20;
            ICellStyle style = workbook.CreateCellStyle();
            style.BorderTop = BorderStyle.Thick;
            style.TopBorderColor = 256;
            style.BorderLeft = BorderStyle.Thick;
            style.LeftBorderColor = 256;
            style.BorderRight = BorderStyle.Thick;
            style.RightBorderColor = 256;
            style.BorderBottom = BorderStyle.Thick;
            style.BottomBorderColor = 256;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            style.SetFont(font1);

            IRow rowTop = sheet.CreateRow(1);
            ICell с1 = rowTop.CreateCell(1);
            с1.SetCellValue("Фамилия");
            с1.CellStyle = style;

            //   с1.CellStyle = style1;
            ICell с2 = rowTop.CreateCell(2);
            с2.SetCellValue("Имя");
            с2.CellStyle = style;
            ICell с3 = rowTop.CreateCell(3);
            с3.SetCellValue("Отчество");
            с3.CellStyle = style;
            ICell с4 = rowTop.CreateCell(4);
            с4.SetCellValue("Должность");
            с4.CellStyle = style;
            ICell с5 = rowTop.CreateCell(5);
            с5.SetCellValue("Звание");
            с5.CellStyle = style;
            ICell с6 = rowTop.CreateCell(6);
            с6.SetCellValue("Подразделение");
            с6.CellStyle = style;
            ICell с7 = rowTop.CreateCell(7);
            с7.SetCellValue("Уволен?");
            с7.CellStyle = style;
            var count = rowTop.Count() + 1;
            for (int item = 1; item < count; item++)
            {
                sheet.SetColumnWidth(item, 23 * 256);
            }
            int i = 2;
            if (staffs != null)
            {
                foreach (var item in staffs)
                {
                    IRow row = sheet.CreateRow(i);
                    ICell surnameCellRow = row.CreateCell(1);
                    surnameCellRow.SetCellValue(item.Second);
                    ICell nameCellRow = row.CreateCell(2);
                    nameCellRow.SetCellValue(item.First);
                    ICell middleNameCellRow = row.CreateCell(3);
                    middleNameCellRow.SetCellValue(item.MiddleName);
                    ICell positionCellRow = row.CreateCell(4);
                    positionCellRow.SetCellValue(item.Position.Name);
                    ICell RankCellRow = row.CreateCell(5);
                    RankCellRow.SetCellValue(item.Rank.Name);
                    ICell SubDepartmentCellRow = row.CreateCell(6);
                    SubDepartmentCellRow.SetCellValue(item.SubDepartmen.Name);
                    ICell FiredCellRow = row.CreateCell(7);
                    FiredCellRow.SetCellValue(item.Fired == true ? "Уволен" : "Работает");
                    ++i;
                }
            }
            workbook.Write(result);

            return result;
        }
    }
}
