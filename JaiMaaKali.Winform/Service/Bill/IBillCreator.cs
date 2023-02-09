using JaiMaaKali.WinForm.Service.WholeSaleClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.Bill
{
    public interface IBillCreator
    {
        Bill CreateBillForTotalAmount(Customer party,decimal taxRate, decimal discountRate, decimal totalAmount, DateTime? billDate = null);
    }
}
