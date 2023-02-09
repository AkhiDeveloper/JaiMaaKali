using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Data
{
    public class CSVFileStatergy<T>
        : IFileStatergy<T> where T : class
    {

        public IList<T> ReadData(string file_path)
        {
            if (!File.Exists(file_path))
            {
                throw new FileNotFoundException();
            }
            using (var reader = new StreamReader(file_path))
            {
                using (var csv_reader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csv_reader.GetRecords<T>().ToList();
                }
            }
        }

        public void WriteData(T data, string output_folder, string? folder_name = null)
        {
            throw new NotImplementedException();
        }
    }
}
