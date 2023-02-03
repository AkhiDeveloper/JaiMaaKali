using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.DataMining
{
    public class DateTimeCombiner : System.ComponentModel.TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var dateTime = value.ToString().Split(',');
            return DateTime.ParseExact(dateTime[0] + " " + dateTime[1], "yyyy/MM/dd h:mm tt", CultureInfo.InvariantCulture);
        }
    }
}
