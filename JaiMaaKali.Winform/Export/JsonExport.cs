using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JaiMaaKali.WinForm.Export
{
    public class JsonExport<T>
        : IExport<T> where T : class
    {
        public void Export(T data, string path, string? filename = null)
        {
            filename = filename ?? Path.Combine(path + Path.GetTempFileName());
            var filenameWithExt = Path.ChangeExtension(path, "json");
            using(Stream fileStream = new FileStream(filenameWithExt, FileMode.Create))
            {
                string jsonString = JsonSerializer.Serialize(data);
                byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
                fileStream.Write(bytes, 0, bytes.Length);
            }
            
        }

        public void ExportList(IList<T> data, string path, string? filename = null)
        {
            filename = filename ?? Path.Combine(path + Path.GetTempFileName());
            var filenameWithExt = Path.ChangeExtension(path, "json");
            using (Stream fileStream = new FileStream(filenameWithExt, FileMode.Create))
            {
                string jsonString = JsonSerializer.Serialize(data);
                byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }

        
    }

    public class JsonExport
            : IExport
    {
        public void Export<T>(T data, string path, string? filename = null)
        {
            Directory.CreateDirectory(path);
            filename = filename ?? Path.GetTempFileName();
            var filepath = Path.Combine(path, filename);
            var filepathWithExt = Path.ChangeExtension(filepath, "json");
            using (Stream fileStream = new FileStream(filepathWithExt, FileMode.Create))
            {
                string jsonString = JsonSerializer.Serialize(data);
                byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }

        public void ExportList<T>(IList<T> data, string path, string? filename = null)
        {
            filename = filename ?? Path.GetTempFileName();
            Directory.CreateDirectory(path);
            for(int i = 0; i < data.Count; i++) 
            {
                var filepath = Path.Combine(path, filename + "_" + (i+1).ToString());
                var filepathWithExt = Path.ChangeExtension(filepath , "json");
                using (Stream fileStream = new FileStream(filepathWithExt, FileMode.Create))
                {
                    string jsonString = JsonSerializer.Serialize(data[i]);
                    byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            }
            
        }
    }
}
