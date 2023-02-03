using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.DataMining
{
    public interface IDataManager<T>
        where T : class
    {
        void SetFileStatergy(IFileStatergy<T> file_statergy);
        void MineDataFromFile(string file_path);
        IList<T> Data { get; }
    }
}
