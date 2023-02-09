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
        void ExportList(IList<T> data, string path, string? filename = null);
        void Export(T data, string path, string? filename = null);
    }

    public interface IExport
    {
        void ExportList<T>(IList<T> data, string path, string? filename = null);
        void Export<T>(T data, string path, string? filename = null);
    }
}
