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
        private int _totalItems;
        

        public Bill(Customer party, 
            decimal taxRate, 
            decimal discountRate, 
            DateTime? billDate = null)
        {
            _party = party;
            _taxRate = taxRate;
            _discountRate = discountRate;
            _billItems = new List<BillItem>();
            _totalItems = 0;
            _billDate = billDate ?? DateTime.Now;
        }
        public void AddBillItem(BillItem item)
        {
            _totalItems++;
            item.SN = _totalItems;
            _billItems.Add(item);
        }

        public void AddBillItems(IEnumerable<BillItem> items)
        {
            foreach (var item in items)
            {
                AddBillItem(item);
            }
        }

        public int TotalItems { get => _totalItems; }

        public int GetQuantityOfBillItem(int item_sn)
        {
            return _billItems[item_sn-1].Quantity;
        }

        public void UpdateBillItemAt(int sn, BillItem item)
        {
            if(sn < 0 || sn > _billItems.Count())
                throw new ArgumentOutOfRangeException("Sn is not in the bill items");
            var existedItem = _billItems.FirstOrDefault(x => x.SN == sn);
            existedItem.Description = item.Description;
            existedItem.Rate = item.Rate;
            existedItem.Quantity = item.Quantity;
        }

        public void ChangeQuantityOfBillItem(int item_sn, int quantity)
        {
            var item = _billItems[item_sn - 1];
            item.Quantity = quantity;
        }

        public void RemoveBillItemAt(int sn)
        {
            if (sn < 0 || sn > _totalItems)
                throw new ArgumentOutOfRangeException("Sn is not in the bill items");
            _billItems.RemoveAt(sn - 1);
            _totalItems--;
            foreach(var item in _billItems.Where(x=>x.SN > sn))
            {
                item.SN--;
            }
        }

        public DateTime BillDate { get => _billDate; }
        public Customer Party { get => _party; }
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

        public IList<BillItem> BillItems { get => _billItems; }
        public decimal GetSubTotal()
        {
            return decimal.Round(_billItems.Sum(x => x.Amount),2,MidpointRounding.ToPositiveInfinity);
        }

        public decimal GetDiscountAmount()
        {
            return decimal.Round(GetSubTotal() * _discountRate,2,MidpointRounding.ToPositiveInfinity);
        }

        public decimal GetTaxableAmount()
        {
            return decimal.Round(GetSubTotal() - GetDiscountAmount(), 2, MidpointRounding.ToPositiveInfinity);
        }

        public decimal GetTaxAmount()
        {
            return decimal.Round(GetTaxableAmount() * _taxRate, 2, MidpointRounding.ToPositiveInfinity);
        }

        public decimal GetTotalAmount()
        {
            return decimal.Round(GetTaxableAmount() + GetTaxAmount(), 2, MidpointRounding.ToPositiveInfinity);
        }
    }

    public class BillItem
    {
        public int SN { get; set; }
        public string Description { get; set; }

        private int _quantity;
        public int Quantity { 
            get=>_quantity; 
            set 
            {
                if(value < 0) 
                    throw new ArgumentOutOfRangeException
                        ("Quantity should be in positive");

                _quantity = value;
            } 
        }

        public decimal Rate { get; set; }
        public decimal Amount { get => decimal.Round(Quantity * Rate, 2, MidpointRounding.ToPositiveInfinity); }
    }
}
