using Data.Entityes;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStaff.Models;

namespace WebStaff.Helpers
{
    public class DocParse
    {
        public MemoryStream AppointAndTransfer(StaffViewModel model, PositionViewModel position, SubDepartmentViewModel subDepartment)
        {
            MemoryStream result = new MemoryStream();
            XWPFDocument doc = new XWPFDocument();
            XWPFParagraph para = doc.CreateParagraph();
            XWPFRun run1 = para.CreateRun();
            run1.SetText(position.Name + " " + subDepartment.Name + " " + model.Second + " " + model.First + " " + model.MiddleName);
            XWPFParagraph para3 = doc.CreateParagraph();
            XWPFRun run2 = para3.CreateRun();
            run2.SetText("Переведен в " + model.SubDepartmen.Name + " на должность " + model.Position.Name);


            run1.FontFamily = (/*setter*/"Times New Roman");
            run1.FontSize = (/*setter*/14);
            run2.FontFamily = (/*setter*/"Times New Roman");
            run2.FontSize = (/*setter*/14);

            doc.Write(result);

            return result;
        }

        private void AddCell(XWPFTableCell cell, string text)
        {
            XWPFParagraph paragraph = cell.AddParagraph();
            XWPFRun run = paragraph.CreateRun();
            run.SetText(text);
            run.FontFamily = "Times New Roman";
            run.FontSize = 12;
        }

        public MemoryStream CreateTableDoc(List<StaffViewModel> staffs, int countRecord = 0)
        {

            MemoryStream result = new MemoryStream();
            XWPFDocument doc = new XWPFDocument();
            XWPFStyles styles = doc.CreateStyles();
            XWPFParagraph pCha = doc.CreateParagraph();
            XWPFTable table = doc.CreateTable(countRecord + 1, 7);
            table.Width = 3500;
            AddCell(table.GetRow(0).GetCell(0), "Фамилия");
            AddCell(table.GetRow(0).GetCell(1), "Имя");
            AddCell(table.GetRow(0).GetCell(2), "Отчество");
            AddCell(table.GetRow(0).GetCell(3), "Должность");
            AddCell(table.GetRow(0).GetCell(4), "Звание");
            AddCell(table.GetRow(0).GetCell(5), "Подразделение");
            AddCell(table.GetRow(0).GetCell(6), "Уволен");
            int i = 1;
            if (staffs != null)
            {
                foreach (var item in staffs)
                {
                    AddCell(table.GetRow(i).GetCell(0), item.Second);
                    AddCell(table.GetRow(i).GetCell(1), item.First);
                    AddCell(table.GetRow(i).GetCell(2), item.MiddleName);
                    AddCell(table.GetRow(i).GetCell(3), item.Position.Name);
                    AddCell(table.GetRow(i).GetCell(4), item.Rank.Name);
                    AddCell(table.GetRow(i).GetCell(5), item.SubDepartmen.Name);
                    AddCell(table.GetRow(i).GetCell(6), item.Fired == true ? "Уволен" : "Работает");
                    // table.GetRow(i).GetCell(0).SetText(item.Second);
                    ++i;
                }
            }
            table.ColBandSize = 14;

            doc.Write(result);
            return result;
        }

       
    }
}
