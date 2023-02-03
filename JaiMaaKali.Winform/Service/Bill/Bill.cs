using JaiMaaKali.WinForm.Service.WholeSaleClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.Bill
{
    public class Bill
    {
        private readonly DateTime _billDate;
        private readonly Customer _party;
        private decimal _taxRate;
        private decimal _discountRate;
        private IList<BillItem> _billItems;


        public void AddBillItem(BillItem item)
        {
            var sn = _billItems.Count()+1;
            item.SN = sn;
            _billItems.Add(item);
        }

        public void AddBillItems(IEnumerable<BillItem> items)
        {
            foreach (var item in items)
            {
                AddBillItem(item);
            }
        }

        public void UpdateBillItemAt(int sn, BillItem item)
        {
            if(sn < 0 || sn > _billItems.Count())
                throw new ArgumentOutOfRangeException("Sn is not in the bill items");
            var existedItem = _billItems.FirstOrDefault(x => x.SN == sn);
            existedItem.Descripton = item.Descripton;
            existedItem.Rate = item.Rate;
            existedItem.Quantity = item.Quantity;
        }

        public void RemoveBillItemAt(int sn)
        {
            if (sn < 0 || sn > _billItems.Count())
                throw new ArgumentOutOfRangeException("Sn is not in the bill items");
            _billItems.RemoveAt(sn - 1);
            foreach(var item in _billItems.Where(x=>x.SN > sn))
            {
                item.SN--;
            }
        }

        public DateTime BillDate { get=>_billDate; }
        public Customer Party { get=>_party;}
        public decimal TaxRate { 
            get=>_taxRate;
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException("Tax Rate should be between 0 and 1");
                _taxRate = value;
            }
        }

        public decimal DiscountRate { 
            get=>_discountRate;
            set {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException("Discount Rate should be between 0 and 1");
                _taxRate = value;
            } 
        }

        public IEnumerable<BillItem> BillItems { get => _billItems; }
        public decimal GetSubTotal()
        {
            return _billItems.Sum(x => x.Amount);
        }

        public decimal GetDiscountAmount()
        {
            return GetSubTotal() * _discountRate;
        }

        public decimal GetTaxableAmount()
        {
            return GetSubTotal() - GetDiscountAmount();
        }

        public decimal GetTaxAmount()
        {
            return GetTaxableAmount() * _taxRate;
        }

        public decimal GetTotalAmount()
        {
            return GetTaxableAmount() + GetTaxAmount();
        }

        public Bill(Customer party)
        {

            _billItems = new List<BillItem>();
            _party = party;
            
        }


    }

    public class BillItem
    {
        public int SN { get; set; }
        public string Descripton { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get => Quantity * Rate; }
    }
}
