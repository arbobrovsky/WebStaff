using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

using System.Text.RegularExpressions;
using System.IO;

namespace WebStaff.Helpers
{
    public class OpenXmlExcel
    {
        public MemoryStream CreateExcel()
        {
            MemoryStream result = new MemoryStream();
            var document = SpreadsheetDocument.Create(result, SpreadsheetDocumentType.Workbook);
            

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

            FileVersion fv = new FileVersion();
            fv.ApplicationName = "Microsoft Office Excel";
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            WorkbookStylesPart wbsp = workbookPart.AddNewPart<WorkbookStylesPart>();

            // Добавляем в документ набор стилей
            wbsp.Stylesheet = GenerateStyleSheet();
            wbsp.Stylesheet.Save();



            // Задаем колонки и их ширину
            Columns lstColumns = worksheetPart.Worksheet.GetFirstChild<Columns>();
            Boolean needToInsertColumns = false;
            if (lstColumns == null)
            {
                lstColumns = new Columns();
                needToInsertColumns = true;
            }
            lstColumns.Append(new Column() { Min = 1, Max = 10, Width = 20, CustomWidth = true });
            lstColumns.Append(new Column() { Min = 2, Max = 10, Width = 20, CustomWidth = true });
            lstColumns.Append(new Column() { Min = 3, Max = 10, Width = 20, CustomWidth = true });
            lstColumns.Append(new Column() { Min = 4, Max = 10, Width = 20, CustomWidth = true });
            lstColumns.Append(new Column() { Min = 5, Max = 10, Width = 20, CustomWidth = true });
            lstColumns.Append(new Column() { Min = 6, Max = 10, Width = 20, CustomWidth = true });
            lstColumns.Append(new Column() { Min = 7, Max = 10, Width = 20, CustomWidth = true });
            if (needToInsertColumns)
                worksheetPart.Worksheet.InsertAt(lstColumns, 0);


            //Создаем лист в книге
            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Отчет по входящим" };
            sheets.Append(sheet);

            SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

            //Добавим заголовки в первую строку
            Row row = new Row() { RowIndex = 1 };
            sheetData.Append(row);

            InsertCell(row, 1, "Стиль 1", CellValues.String, 5);
            InsertCell(row, 2, "Стиль 2", CellValues.String, 5);
            InsertCell(row, 3, "Стиль 3", CellValues.String, 5);
            InsertCell(row, 4, "Стиль 4", CellValues.String, 5);
            InsertCell(row, 5, "Стиль 5", CellValues.String, 5);
            InsertCell(row, 6, "Стиль 6", CellValues.String, 5);
            InsertCell(row, 7, "Стиль 7", CellValues.String, 5);

            // Добавляем в строку все стили подряд.
            row = new Row() { RowIndex = 2 };
            sheetData.Append(row);

            InsertCell(row, 1, "1", CellValues.Number, 1);
            InsertCell(row, 2, ReplaceHexadecimalSymbols("Тест"), CellValues.String, 2);
            InsertCell(row, 3, ReplaceHexadecimalSymbols("Тест"), CellValues.String, 3);
            InsertCell(row, 4, ReplaceHexadecimalSymbols("Тест"), CellValues.String, 4);
            InsertCell(row, 5, ReplaceHexadecimalSymbols("Тест"), CellValues.String, 5);
            InsertCell(row, 6, ReplaceHexadecimalSymbols("01.01.2017"), CellValues.String, 6);
            InsertCell(row, 7, ReplaceHexadecimalSymbols("123"), CellValues.String, 7);

            workbookPart.Workbook.Save();

            document.Close();
            result.Seek(0, SeekOrigin.Begin);

            return result;

        }
        //Добавление Ячейки в строку (На вход подаем: строку, номер колонки, тип значения, стиль)
        static void InsertCell(Row row, int cell_num, string val, CellValues type, uint styleIndex)
        {
            Cell refCell = null;
            Cell newCell = new Cell() { CellReference = cell_num.ToString() + ":" + row.RowIndex.ToString(), StyleIndex = styleIndex };
            row.InsertBefore(newCell, refCell);

            // Устанавливает тип значения.
            newCell.CellValue = new CellValue(val);
            newCell.DataType = new EnumValue<CellValues>(type);

        }

        //Важный метод, при вставки текстовых значений надо использовать.
        //Метод убирает из строки запрещенные спец символы.
        //Если не использовать, то при наличии в строке таких символов, вылетит ошибка.
        static string ReplaceHexadecimalSymbols(string txt)
        {
            string r = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]";
            return Regex.Replace(txt, r, "", RegexOptions.Compiled);
        }



        //Метод генерирует стили для ячеек (за основу взят код, найденный где-то в интернете)
        static Stylesheet GenerateStyleSheet()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(                                                               // Стиль под номером 0 - Шрифт по умолчанию.
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Стиль под номером 1 - Жирный шрифт Times New Roman.
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" }),
                    new Font(                                                               // Стиль под номером 2 - Обычный шрифт Times New Roman.
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" }),
                    new Font(                                                               // Стиль под номером 3 - Шрифт Times New Roman размером 14.
                        new FontSize() { Val = 14 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" })
                ),
                new Fills(
                    new Fill(                                                           // Стиль под номером 0 - Заполнение ячейки по умолчанию.
                        new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(                                                           // Стиль под номером 1 - Заполнение ячейки серым цветом
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFAAAAAA" } }
                            )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Стиль под номером 2 - Заполнение ячейки красным.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFFFAAAA" } }
                        )
                        { PatternType = PatternValues.Solid })
                )
                ,
                new Borders(
                    new Border(                                                         // Стиль под номером 0 - Грани.
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
                    new Border(                                                         // Стиль под номером 1 - Грани
                        new LeftBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Medium },
                        new RightBorder(
                            new Color() { Indexed = (UInt32Value)64U }
                        )
                        { Style = BorderStyleValues.Medium },
                        new TopBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Medium },
                        new BottomBorder(
                            new Color() { Indexed = (UInt32Value)64U }
                        )
                        { Style = BorderStyleValues.Medium },
                        new DiagonalBorder()),
                    new Border(                                                         // Стиль под номером 2 - Грани.
                        new LeftBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new RightBorder(
                            new Color() { Indexed = (UInt32Value)64U }
                        )
                        { Style = BorderStyleValues.Thin },
                        new TopBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new BottomBorder(
                            new Color() { Indexed = (UInt32Value)64U }
                        )
                        { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 },                          // Стиль под номером 0 - The default cell style.  (по умолчанию)
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }) { FontId = 1, FillId = 2, BorderId = 1, ApplyFont = true },       // Стиль под номером 1 - Bold 
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }) { FontId = 2, FillId = 0, BorderId = 2, ApplyFont = true },       // Стиль под номером 2 - REgular
                    new CellFormat() { FontId = 3, FillId = 0, BorderId = 2, ApplyFont = true, NumberFormatId = 4 },       // Стиль под номером 3 - Times Roman
                    new CellFormat() { FontId = 0, FillId = 2, BorderId = 0, ApplyFill = true },       // Стиль под номером 4 - Yellow Fill
                    new CellFormat(                                                                   // Стиль под номером 5 - Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    )
                    { FontId = 0, FillId = 0, BorderId = 0, ApplyAlignment = true },
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true },      // Стиль под номером 6 - Border
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Right, Vertical = VerticalAlignmentValues.Center, WrapText = true }) { FontId = 2, FillId = 0, BorderId = 2, ApplyFont = true, NumberFormatId = 4 }       // Стиль под номером 7 - Задает числовой формат полю.
                )
            ); // Выход
        }


    }
}
