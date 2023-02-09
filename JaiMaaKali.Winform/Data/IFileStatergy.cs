using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Data
{
    public interface IFileStatergy<T>
        where T : class
    {
        IList<T> ReadData(string file_path);
        void WriteData(T data, string output_folder, string? folder_name = null);

    }
}
