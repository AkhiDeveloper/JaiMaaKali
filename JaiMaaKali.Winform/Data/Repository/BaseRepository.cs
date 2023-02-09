using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Data.Repository
{
    public class BaseRepository<T>
        : IRepository<T> where T : class
    {
        private IList<T> _entities;

        public BaseRepository()
        {
            _entities = new List<T>();
        }

        public IEnumerable<T> Entities => _entities;

        public void ReadDataFromFile(string filepath, IFileStatergy<T> statergy)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"{filepath} is not found.");
            }
            _entities = statergy.ReadData(filepath);
        }
    }
}
