using JaiMaaKali.WinForm.Service.WholeSaleClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.Bill
{
    public class BillCreator : IBillCreator
    {
        private readonly IEnumerable<BillItem> _billItems;

        public BillCreator(IEnumerable<BillItem> billItems)
        {
            _billItems = billItems.OrderBy(x => x.SN).ToList();
        }

        public Bill CreateBillForTotalAmount(Customer party, decimal taxRate, decimal discountRate, decimal totalAmount, DateTime? billDate = null)
        {
            Bill newbill = new Bill(party, taxRate, discountRate, billDate);
            newbill.AddBillItems(_billItems.Select(x => new BillItem()
            {
                SN = x.SN,
                Quantity = x.Quantity,
                Rate = x.Rate,
                Description= x.Description,
            }));
            while(newbill.GetTotalAmount() > totalAmount) 
            {
                if (newbill.BillItems.Count() <= 1) break;
                newbill.RemoveBillItemAt(newbill.TotalItems);
            }
            decimal increaseBy = totalAmount / newbill.GetTotalAmount();
            for (int i = 0; i < newbill.TotalItems; i++)
            {
                var oldquantity = newbill.GetQuantityOfBillItem(i + 1);
                int newquantity = Decimal.ToInt32(Math.Round(oldquantity * increaseBy));
                newbill.ChangeQuantityOfBillItem(i + 1, newquantity);
            }
            return newbill;
        }
    }
}
