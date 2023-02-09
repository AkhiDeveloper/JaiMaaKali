using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Export.Model
{
    public class BillItem
    {
        public int SN { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get => Quantity * Rate; }
    }
}
