using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Data.Repository
{
    public interface IRepository<T>
        where T : class
    {
        void ReadDataFromFile(string filepath, IFileStatergy<T> statergy);
        IEnumerable<T> Entities { get; }
    }
}
