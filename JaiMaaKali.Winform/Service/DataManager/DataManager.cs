using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.DataMining
{
    public class DataManager<T> : IDataManager<T>
        where T : class
    {
        private IFileStatergy<T> _statergy;
        private IList<T> _data;

        public DataManager(IFileStatergy<T> fileStatergy)
        {
            _data = new List<T>();
            _statergy = fileStatergy;
        }

        public IList<T> Data => _data;

        public void MineDataFromFile(string file_path)
        {
            _data.Clear();
            _data = _statergy.ReadData(file_path);
        }

        public void SetFileStatergy(IFileStatergy<T> file_statergy)
        {
            _statergy = file_statergy;
        }
    }
}
