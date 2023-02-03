using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.DataMining
{
    public class PurchaseProduct
    {
        [Name("Vendor Invoiced Date")]
        //[TypeConverter(typeof(DateTimeCombiner))]
        public DateTime InvoiceDate { get; set; }

        [Name("Vendor Invoice Number")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Name("ERP Code")]
        public string ProductCode { get; set; } = string.Empty;

        [Name("SKU")] 
        public string ProductName { get; set; } = string.Empty;

        [Name("Brand")] 
        public string BrandName { get; set; } = string.Empty;

        [Name("Quantity")]
        public int Quantity { get; set; }

        [Name("Damages")]
        public int DamageQuantity { get; set; }

        [Name("Shortages")]
        public int ShortageQuantity { get; set; }

        [Name("Gross Amount")]
        public decimal GrossAmount { get; set; }

        [Name("Promotion Discount")]
        public decimal PromotionDiscount { get; set; }

        [Name("Bill Discount")]
        public decimal BillDiscount { get; set; }

        [Name("Trade Discount")]
        public decimal TradeDiscount { get; set; }

        [Name("Remarks")]
        public string Remarks { get; set; } = string.Empty;
    }


}
