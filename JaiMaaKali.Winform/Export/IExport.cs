using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Export
{
    public interface IExport<T>
        where T : class
    {
        string ExportToFile(IList<T> data, string path);
    }
}
