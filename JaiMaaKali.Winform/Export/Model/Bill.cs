using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Export.Model
{
    public class Bill
    {
        public string BillDate { get; set; }
        public string PartyName { get; set; }
        public string Address { get; set; }
        public string PAN { get; set; }
        public decimal TaxRate { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxableValue { get; set; }
        public decimal VATAmount { get; set; }
        public decimal Total { get; set; }
        public IList<BillItem> BillItems { get; set; } = new List<BillItem>();  
    }
}
