using JaiMaaKali.WinForm.Service.ClaimGenerator;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Humanizer;
using System.Globalization;

namespace JaiMaaKali.WinForm.Export
{
    public class TransportClaimExcelExport : IExport<TransportClaim>
    {
        private ExcelWorksheet _format;
        private ExcelPackage _excelpack;

        public TransportClaimExcelExport(string format_file_path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _excelpack = new ExcelPackage(format_file_path);
            _format = _excelpack.Workbook.Worksheets[0];
        }

        ~TransportClaimExcelExport()
        {
            _excelpack.Dispose();
        }

        public string ExportToFile(IList<TransportClaim> data, string path)
        {
            //Checking their is data
            if(data.Count() < 1) throw new ArgumentException("No data found for the year and month.");

            //Creating File
            var filename = $"Transport_Claim_{DateTime.Now.ToString("yyyyMMddhhmm")}" + ".xlsx";
            var filepath = Path.Combine(path, filename);
            File.Create(filepath).Close();

            //Creating Excel Workbook
            var exportexcelpack = new ExcelPackage(new FileInfo(filepath));
            
            //Extracting Date of Data
            var date = data.GroupBy(x => x.BillDate)
                .Select(x => x.Key)
                .FirstOrDefault();

            //Writing to heading
            var _targetsheet = exportexcelpack.Workbook.Worksheets.Add("Transport Claim", _format);
            _targetsheet.Cells["F5"].Value = $"Date: {DateTime.Now.ToString("dd/MM/yyyy")}";
            _targetsheet.Cells["C9"].Value = $"Transport Claim for {date.ToString("yyyy MMMM")}";

            //Insert Rows
            _targetsheet.InsertRow(16, data.Count() - 1);
            ExcelRow total_row = _targetsheet.Row(16 + data.Count());
            total_row.Style.Font.Bold = true;
            _targetsheet.Cells[total_row.Row, 4].Value = data.Sum(x => x.Cartoon);
            _targetsheet.Cells[total_row.Row, 5].Value = data.Max(x => x.Rate);
            _targetsheet.Cells[total_row.Row, 6].Value = data.Sum(x => x.Amount);

            //Creating table border
            ExcelRange table_range = _targetsheet.Cells[15, 2, total_row.Row, 6];
            table_range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            table_range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            table_range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            table_range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            //Ruppee in word Section
            _targetsheet.Cells[total_row.Row,2].Offset(2, 0).Value = (Int32
                .Parse(data.Sum(x => x.Amount).ToString())
                .ToWords(CultureInfo.CreateSpecificCulture("ne-NP")) +
                " Ruppee Only").ApplyCase(LetterCasing.Title);

            //Footer of excel
            ExcelRange destination_tail = _targetsheet.Cells[49, 1, 50, 9];
            ExcelRange source_tail = _targetsheet.Cells[49 + data.Count() - 1, 1, 50 + data.Count() - 1, 9];
            source_tail.Copy(destination_tail);
            source_tail.CopyStyles(destination_tail);
            source_tail.Clear();
           
            //Table data
            for (int i=0; i<data.Count(); i++)
            {
                _targetsheet.Cells["B16"].Offset(i,0).Value = data[i].BillDate.ToString("dd/MM/yyyy");
                _targetsheet.Cells["B16"].Offset(i, 1).Value = data[i].BillNumber;
                _targetsheet.Cells["B16"].Offset(i, 2).Value = data[i].Cartoon;
                _targetsheet.Cells["B16"].Offset(i, 3).Value = data[i].Rate;
                _targetsheet.Cells["B16"].Offset(i, 4).Value = data[i].Amount;
            }

            //Finishing
            _targetsheet.Columns.AutoFit();
            exportexcelpack.Save();
            exportexcelpack.Dispose();
            return filepath;
        }
    }
}
